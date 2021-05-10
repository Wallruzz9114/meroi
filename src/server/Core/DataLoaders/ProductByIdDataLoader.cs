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
    public class ProductByIdDataLoader : BatchDataLoader<int, Product>
    {
        private readonly IDbContextFactory<AppDbContext> _dbContextFactory;

        public ProductByIdDataLoader(IBatchScheduler batchScheduler, IDbContextFactory<AppDbContext> dbContextFactory) : base(batchScheduler)
        {
            _dbContextFactory = dbContextFactory ??
                throw new ArgumentNullException(nameof(dbContextFactory));
        }

        protected override async Task<IReadOnlyDictionary<int, Product>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            await using var dbContext = _dbContextFactory.CreateDbContext();
            var productDictionary = await dbContext.Products
                .Where(u => keys.Contains(u.Id))
                .ToDictionaryAsync(t => t.Id, cancellationToken);

            return productDictionary;
        }
    }
}