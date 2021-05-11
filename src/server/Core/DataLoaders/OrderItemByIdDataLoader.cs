using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Data;
using GreenDonut;
using HotChocolate.DataLoader;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace Core.DataLoaders
{
    public class OrderItemByIdDataLoader : BatchDataLoader<int, OrderItem>
    {
        private readonly IDbContextFactory<AppDbContext> _dbContextFactory;

        public OrderItemByIdDataLoader(IBatchScheduler batchScheduler, IDbContextFactory<AppDbContext> dbContextFactory) : base(batchScheduler)
        {
            _dbContextFactory = dbContextFactory ??
                throw new ArgumentNullException(nameof(dbContextFactory));
        }

        protected override async Task<IReadOnlyDictionary<int, OrderItem>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            await using var dbContext = _dbContextFactory.CreateDbContext();
            var orderItemDictionary = await dbContext.OrderItems
                .Where(oi => keys.Contains(oi.Id))
                .ToDictionaryAsync(oi => oi.Id, cancellationToken);

            return orderItemDictionary;
        }
    }
}