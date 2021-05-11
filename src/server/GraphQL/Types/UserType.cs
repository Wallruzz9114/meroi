using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Core.DataLoaders;
using Data;
using Data.Extensions;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace GraphQL.Types
{
    public class UserType : ObjectType<User>
    {
        protected override void Configure(IObjectTypeDescriptor<User> descriptor)
        {
            descriptor.Description("Represents a User entity.");

            descriptor.Field(u => u.Id).Description("Represents the user's id");

            descriptor
                .Field(t => t.UserOrders)
                .ResolveWith<UserResolvers>(t => UserResolvers.GetOrdersAsync(default!, default!, default!, default))
                .UseAppDbContext<AppDbContext>()
                .Name("orders");

            descriptor.Field(u => u.Email).Description("Represents the user's email");
            descriptor.Field(u => u.Name).Description("Represents the user's name");

            descriptor.Field(u => u.UserOrders).Description("Represents the user's orders");
            descriptor
                .Field(u => u.UserOrders)
                .ResolveWith<UserResolvers>(r => UserResolvers.GetOrdersAsync(default!, default!, default!, default!))
                .UseAppDbContext<AppDbContext>()
                .Name("orders");

            descriptor.Field(u => u.CreatedAt).Ignore();
            descriptor.Field(u => u.UpdatedAt).Ignore();
            descriptor.Field(u => u.LastAccessedAt).Ignore();
        }

        private class UserResolvers
        {
            public static async Task<IEnumerable<Order>> GetOrdersAsync(User user, [ScopedService] AppDbContext dbContext, OrderByIdDataLoader orderById, CancellationToken cancellationToken)
            {
                var userIds = await dbContext.Users
                    .Where(u => u.Id == user.Id)
                    .Include(u => u.UserOrders)
                    .SelectMany(u => u.UserOrders.Select(t => t.OrderId))
                    .ToArrayAsync(cancellationToken);

                var orders = await orderById.LoadAsync(userIds, cancellationToken);

                return orders;
            }
        }
    }
}