using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.DataLoaders;
using Data;
using Data.Extensions;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace GraphQL.Queries
{
    [ExtendObjectType("Queries")]
    public class OrderQueries
    {
        [UseAppDbContext]
        [GraphQLDescription("Represents the query to get all orders.")]
        public async Task<List<Order>> GetOrdersAsync([ScopedService] AppDbContext dbContext) =>
            await dbContext.Orders.ToListAsync();

        [GraphQLDescription("Represents the query to get an order by id.")]
        public async Task<Order> GetOrderAsync([ID(nameof(Order))] Guid id, OrderByIdDataLoader dataLoader, CancellationToken cancellationToken) =>
            await dataLoader.LoadAsync(id, cancellationToken);
    }
}