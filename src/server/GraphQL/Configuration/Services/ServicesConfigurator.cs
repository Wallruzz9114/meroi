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
                    .AddType<UserQueries>()
                        .AddType<UserType>()
                        .AddDataLoader<OrderByIdDataLoader>()
                    .AddType<OrderQueries>()
                        .AddType<OrderType>()
                        .AddDataLoader<OrderByIdDataLoader>()
                .AddMutationType(t => t.Name("Mutations"))
                    .AddType<UserMutations>()
                    .AddType<OrderMutations>()
                .EnableRelaySupport();
        }
    }
}