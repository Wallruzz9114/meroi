using System.Threading;
using System.Threading.Tasks;
using Data;
using Data.Extensions;
using Data.ViewModels.Inputs;
using Data.ViewModels.Payloads.Users;
using HotChocolate;
using HotChocolate.Types;
using Models.Abstractions;
using Models.Entities;
using BC = BCrypt.Net.BCrypt;

namespace GraphQL.Mutations
{
    [ExtendObjectType("Mutations")]
    [GraphQLDescription("Represents the mutations")]
    public class UserMutations
    {
        [UseAppDbContext]
        public async Task<AddUserPayload> RegisterAsync(AddUserInput input, [ScopedService] AppDbContext dbContext, CancellationToken cancellationToken)
        {
            var hashedPassword = BC.HashPassword(input.Password);

            var newUser = new User
            {
                Name = input.Name,
                Email = input.Email,
                Password = hashedPassword,
                Address = input.Address
            };

            dbContext.Users.Add(newUser);
            await dbContext.SaveChangesAsync(cancellationToken);

            var payload = new AddUserPayload(newUser);

            return payload;
        }

        [UseAppDbContext]
        public async Task<AddUserOrderPayload> AddUsersOrderAsync(AddUserOrderInput input, [ScopedService] AppDbContext context)
        {
            if (input.OrderIds.Count == 0)
            {
                return new AddUserOrderPayload(
                    new UserError
                    {
                        Message = "No orders assigned.",
                        Code = "NO_ORDERS"
                    });
            }

            var user = await context.Users.FindAsync(input.UserId);

            foreach (var orderId in input.OrderIds)
            {
                user.UserOrders.Add(new UserOrder
                {
                    OrderId = orderId
                });
            }

            await context.SaveChangesAsync();

            var payload = new AddUserOrderPayload(user);

            return payload;
        }
    }
}