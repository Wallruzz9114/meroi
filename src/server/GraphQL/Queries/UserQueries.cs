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
    [GraphQLDescription("Represents the queries.")]
    public class UserQueries
    {
        [UseAppDbContext]
        [GraphQLDescription("Represents the query to get all users.")]
        public async Task<List<User>> GetUsersAsync([ScopedService] AppDbContext dbContext) =>
            await dbContext.Users.ToListAsync();

        public async Task<User> GetUserAsync([ID(nameof(User))] int id, UserByIdDataLoader dataLoader, CancellationToken cancellationToken) =>
            await dataLoader.LoadAsync(id, cancellationToken);
    }
}