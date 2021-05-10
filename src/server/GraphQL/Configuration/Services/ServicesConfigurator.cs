using Core.DataLoaders;
using Data;
using GraphQL.Configuration.Services;
using GraphQL.Mutations;
using GraphQL.Queries;
using GraphQL.Types;
using HotChocolate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Configuration.Services
{
    public class ServicesConfigurator : IServicesConfigurator
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddPooledDbContextFactory<AppDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DatabaseConnection")));

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
                    .AddTypeExtension<OrderItemMutations>();
        }
    }
}