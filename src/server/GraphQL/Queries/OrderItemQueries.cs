using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.DataLoaders;
using Data;
using Data.Extensions;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace GraphQL.Queries
{
    [ExtendObjectType("Queries")]
    public class OrderItemQueries
    {
        [UseAppDbContext]
        public async Task<List<OrderItem>> GetOrderItemsAsync([ScopedService] AppDbContext dbContext) =>
            await dbContext.OrderItems.ToListAsync();


        public async Task<OrderItem> GetOrderItemAsync(int id, OrderItemByIdDataLoader dataLoader, CancellationToken cancellationToken) =>
            await dataLoader.LoadAsync(id, cancellationToken);
    }
}