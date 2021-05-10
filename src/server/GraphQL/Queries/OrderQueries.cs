using System.Threading;
using System.Threading.Tasks;
using Core.DataLoaders;
using Data;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using Models.Entities;

namespace GraphQL.Queries
{
    [ExtendObjectType("Queries")]
    public class OrderQueries
    {
        [UseDbContext(typeof(AppDbContext))]
        [GraphQLDescription("Represents the query to get an order by id.")]
        public Task<Order> GetOrder(int id, OrderByIdDataLoader dataLoader, CancellationToken cancellationToken) =>
            dataLoader.LoadAsync(id, cancellationToken);
    }
}