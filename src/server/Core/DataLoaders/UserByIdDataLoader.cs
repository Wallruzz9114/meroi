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
    public class UserByIdDataLoader : BatchDataLoader<int, User>
    {
        private readonly IDbContextFactory<AppDbContext> _dbContextFactory;

        public UserByIdDataLoader(IBatchScheduler batchScheduler, IDbContextFactory<AppDbContext> dbContextFactory) : base(batchScheduler)
        {
            _dbContextFactory = dbContextFactory ??
                throw new ArgumentNullException(nameof(dbContextFactory));
        }

        protected override async Task<IReadOnlyDictionary<int, User>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            await using var dbContext = _dbContextFactory.CreateDbContext();
            var userDictionary = await dbContext.Users
                .Where(u => keys.Contains(u.Id))
                .ToDictionaryAsync(u => u.Id, cancellationToken);

            return userDictionary;
        }
    }
}