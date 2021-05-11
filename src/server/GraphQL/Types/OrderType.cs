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
    public class OrderType : ObjectType<Order>
    {
        protected override void Configure(IObjectTypeDescriptor<Order> descriptor)
        {
            descriptor
                .Field(t => t.UserOrders)
                .ResolveWith<OrderResolvers>(t => OrderResolvers.GetUsersAsync(default!, default!, default!, default))
                .UseAppDbContext<AppDbContext>()
                .Name("users");

            descriptor
                .Field(t => t.OrderItems)
                .ResolveWith<OrderResolvers>(t => OrderResolvers.GetOrderItemsAsync(default!, default!, default!, default))
                .UseAppDbContext<AppDbContext>()
                .Name("orderItems");

            descriptor.Field(u => u.CreatedAt).Ignore();
            descriptor.Field(u => u.UpdatedAt).Ignore();
            descriptor.Field(u => u.LastAccessedAt).Ignore();
        }

        private class OrderResolvers
        {
            public static async Task<IEnumerable<User>> GetUsersAsync(Order order, [ScopedService] AppDbContext dbContext, UserByIdDataLoader dataLoader, CancellationToken cancellationToken)
            {
                var userIds = await dbContext.Users
                    .Where(u => u.Id == order.Id)
                    .Include(u => u.UserOrders)
                    .SelectMany(u => u.UserOrders.Select(t => t.UserId))
                    .ToArrayAsync(cancellationToken);

                var users = await dataLoader.LoadAsync(userIds, cancellationToken);

                return users;
            }

            public static async Task<IEnumerable<OrderItem>> GetOrderItemsAsync(Order order, [ScopedService] AppDbContext dbContext, OrderItemByIdDataLoader dataLoader, CancellationToken cancellationToken)
            {
                var ids = await dbContext.Orders
                    .Where(o => o.Id == order.Id)
                    .Include(o => o.OrderItems)
                    .SelectMany(oi => oi.OrderItems.Select(t => t.Id))
                    .ToArrayAsync(cancellationToken);

                var orderItems = await dataLoader.LoadAsync(ids, cancellationToken);

                return orderItems;
            }
        }
    }
}