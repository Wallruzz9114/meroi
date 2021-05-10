using System.Collections.Generic;
using System.Threading.Tasks;
using Data;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace GraphQL.Queries
{
    [ExtendObjectType("Queries")]
    [GraphQLDescription("Represents the queries.")]
    public class UserQueries
    {
        [UseDbContext(typeof(AppDbContext))]
        [GraphQLDescription("Represents the query to get all commands.")]
        public Task<List<User>> GetUsers([ScopedService] AppDbContext dbContext)
        {
            var users = dbContext.Users.ToListAsync();
            return users;
        }
    }
}