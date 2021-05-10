using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Core.DataLoaders;
using Data;
using Data.Extensions;
using HotChocolate;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace GraphQL.Types
{
    public class OrderType : ObjectType<Order>
    {
        protected override void Configure(IObjectTypeDescriptor<Order> descriptor)
        {
            descriptor
              .ImplementsNode()
              .IdField(t => t.Id)
              .ResolveNode((ctx, id) => ctx.DataLoader<OrderByIdDataLoader>().LoadAsync(id, ctx.RequestAborted));

            descriptor
              .Field(t => t.UserOrders)
              .ResolveWith<OrderResolvers>(t => OrderResolvers.GetUsersAsync(default!, default!, default!, default))
              .UseAppDbContext<AppDbContext>()
              .Name("users");
        }

        private class OrderResolvers
        {
            public static async Task<IEnumerable<User>> GetUsersAsync(Order order, [ScopedService] AppDbContext dbContext, UserByIdDataLoader dataLoader, CancellationToken cancellationToken)
            {
                var orderIds = await dbContext.Users
                    .Where(u => u.Id == order.Id)
                    .Include(u => u.UserOrders)
                    .SelectMany(u => u.UserOrders.Select(t => t.UserId))
                    .ToArrayAsync(cancellationToken);

                var users = await dataLoader.LoadAsync(orderIds, cancellationToken);

                return users;
            }
        }
    }
}