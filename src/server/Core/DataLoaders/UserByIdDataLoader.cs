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
    public class UserByIdDataLoader : BatchDataLoader<Guid, User>
    {
        private readonly IDbContextFactory<AppDbContext> _dbContextFactory;

        public UserByIdDataLoader(IBatchScheduler batchScheduler, IDbContextFactory<AppDbContext> dbContextFactory) : base(batchScheduler)
        {
            _dbContextFactory = dbContextFactory ??
                throw new ArgumentNullException(nameof(dbContextFactory));
        }

        protected override async Task<IReadOnlyDictionary<Guid, User>> LoadBatchAsync(IReadOnlyList<Guid> keys, CancellationToken cancellationToken)
        {
            await using var dbContext = _dbContextFactory.CreateDbContext();
            var userDictionary = await dbContext.Users
                .Where(u => keys.Contains(u.Id))
                .ToDictionaryAsync(t => t.Id, cancellationToken);

            return userDictionary;
        }
    }
}