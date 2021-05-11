using System;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Core.DataLoaders;
using Core.Services;
using Core.Utilities;
using Data;
using Data.Interfaces;
using Data.ViewModels;
using GraphQL.Configuration.Services;
using GraphQL.Mutations;
using GraphQL.Queries;
using GraphQL.Types;
using HotChocolate;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace API.Configuration.Services
{
    public class ServicesConfigurator : IServicesConfigurator
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddPooledDbContextFactory<AppDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DatabaseConnection")));

            services.AddCors(options =>
                options.AddPolicy("DefaultPolicy", builder =>
                    builder.AllowAnyHeader().WithMethods("GET", "POST").WithOrigins("*")));

            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddHttpContextAccessor();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateIssuerSigningKey = true,
                    ValidAudience = "audience",
                    ValidIssuer = "issuer",
                    RequireSignedTokens = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(StringGenerator.GenerateRandomString()))
                };

                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
            });

            services.AddAuthorization(x =>
            {
                x.AddPolicy("hr-department", builder =>
                    builder
                        .RequireAuthenticatedUser()
                        .RequireRole("hr")
                );

                x.AddPolicy("DevDepartment", builder =>
                    builder.RequireRole("dev")
                );
            });

            services
                .AddGraphQLServer()
                .AddQueryType(t => t.Name("Queries"))
                    .AddTypeExtension<UserQueries>()
                        .AddType<UserType>()
                        .AddDataLoader<UserByIdDataLoader>()
                    .AddTypeExtension<OrderQueries>()
                        .AddType<OrderType>()
                        .AddDataLoader<OrderByIdDataLoader>()
                    .AddTypeExtension<OrderItemQueries>()
                        .AddDataLoader<OrderItemByIdDataLoader>()
                    .AddTypeExtension<ProductQueries>()
                        .AddDataLoader<ProductByIdDataLoader>()
                .AddMutationType(t => t.Name("Mutations"))
                    .AddTypeExtension<UserMutations>()
                    .AddTypeExtension<OrderMutations>()
                    .AddTypeExtension<ProductMutations>()
                    .AddTypeExtension<OrderItemMutations>()
                .AddAuthorization()
                .AddHttpRequestInterceptor((context, executor, builder, ct) =>
                    {
                        builder.SetProperty("currentUser",
                            new CurrentUser
                            {
                                UserId = context.User.FindFirstValue(ClaimTypes.NameIdentifier),
                                Claims = context.User.Claims.Select(x => $"{x.Type} : {x.Value}").ToList()
                            });

                        return new ValueTask();
                    });
        }
    }
}