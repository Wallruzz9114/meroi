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
    public class OrderByIdDataLoader : BatchDataLoader<Guid, Order>
    {
        private readonly IDbContextFactory<AppDbContext> _dbContextFactory;

        public OrderByIdDataLoader(IBatchScheduler batchScheduler, IDbContextFactory<AppDbContext> dbContextFactory) : base(batchScheduler)
        {
            _dbContextFactory = dbContextFactory ??
                throw new ArgumentNullException(nameof(dbContextFactory));
        }

        protected override async Task<IReadOnlyDictionary<Guid, Order>> LoadBatchAsync(IReadOnlyList<Guid> keys, CancellationToken cancellationToken)
        {
            await using var dbContext = _dbContextFactory.CreateDbContext();
            var orderDictionary = await dbContext.Orders
                .Where(s => keys.Contains(s.Id))
                .ToDictionaryAsync(t => t.Id, cancellationToken);

            return orderDictionary;
        }
    }
}