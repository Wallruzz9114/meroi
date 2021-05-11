using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Core.DataLoaders;
using Data;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace GraphQL.Types
{
    public class OrderItemType : ObjectType<OrderItem>
    {
        protected override void Configure(IObjectTypeDescriptor<OrderItem> descriptor)
        {
            descriptor
                .Field(t => t.Product)
                .ResolveWith<OrderItemResolvers>(r => OrderItemResolvers.GetProductsAsync(default!, default!, default!, default!))
                .Name("product");

            descriptor.Field(u => u.CreatedAt).Ignore();
            descriptor.Field(u => u.UpdatedAt).Ignore();
            descriptor.Field(u => u.LastAccessedAt).Ignore();
        }

        private class OrderItemResolvers
        {
            public static async Task<IEnumerable<Product>> GetProductsAsync(OrderItem orderItem, [ScopedService] AppDbContext dbContext, ProductByIdDataLoader dataLoader, CancellationToken cancellationToken)
            {
                var ids = await dbContext.Products
                    .Where(p => p.Id == orderItem.ProductId)
                    .Select(col => col.Id)
                    .ToArrayAsync(cancellationToken);

                var products = await dataLoader.LoadAsync(ids, cancellationToken);

                return products;
            }
        }
    }
}