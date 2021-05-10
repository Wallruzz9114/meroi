using System.Threading;
using System.Threading.Tasks;
using Data;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using Models.Entities;
using Tutorial.ViewModels.Inputs;
using Tutorial.ViewModels.Payloads;

namespace GraphQL.Mutations
{
    [ExtendObjectType("Mutations")]
    [GraphQLDescription("Represents the mutations")]
    public class UserMutations
    {
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddUserPayload> AddUserAsync(AddUserInput input, [ScopedService] AppDbContext dbContext, CancellationToken cancellationToken)
        {
            var newUser = new User
            {
                Name = input.Name,
                Email = input.Email
            };

            dbContext.Users.Add(newUser);
            await dbContext.SaveChangesAsync(cancellationToken);

            var payload = new AddUserPayload(newUser);

            return payload;
        }
    }
}