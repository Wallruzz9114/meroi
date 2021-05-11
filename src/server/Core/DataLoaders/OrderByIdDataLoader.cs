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
    public class OrderByIdDataLoader : BatchDataLoader<int, Order>
    {
        private readonly IDbContextFactory<AppDbContext> _dbContextFactory;

        public OrderByIdDataLoader(IBatchScheduler batchScheduler, IDbContextFactory<AppDbContext> dbContextFactory) : base(batchScheduler)
        {
            _dbContextFactory = dbContextFactory ??
                throw new ArgumentNullException(nameof(dbContextFactory));
        }

        protected override async Task<IReadOnlyDictionary<int, Order>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            await using var dbContext = _dbContextFactory.CreateDbContext();
            var orderDictionary = await dbContext.Orders
                .Where(o => keys.Contains(o.Id))
                .ToDictionaryAsync(o => o.Id, cancellationToken);

            return orderDictionary;
        }
    }
}