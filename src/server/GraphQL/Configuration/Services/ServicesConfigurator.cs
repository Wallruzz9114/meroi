using Data;
using Data.ViewModels.Types;
using GraphQL.Configuration.Services;
using GraphQL.Mutations;
using GraphQL.Queries;
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
                    .AddType<UserType>()
                    .AddType<UserQueries>()
                .AddMutationType(t => t.Name("Mutations"))
                    .AddType<UserMutations>()
                .AddFiltering()
                .AddSorting();
        }
    }
}