using System.Threading.Tasks;
using Data;
using Data.Extensions;
using Data.ViewModels.Inputs;
using Data.ViewModels.Payloads.OrderItems;
using HotChocolate;
using HotChocolate.Types;
using Models.Entities;

namespace GraphQL.Mutations
{
    [ExtendObjectType("Mutations")]
    public class OrderItemMutations
    {
        [UseAppDbContext]
        public async Task<AddOrderItemPayload> AddOrderItemAsync(AddOrderItemInput input, [ScopedService] AppDbContext context)
        {
            var orderItem = new OrderItem
            {
                OrderId = input.OrderId,
                ProductId = input.ProductId,
                Count = input.Count
            };

            context.OrderItems.Add(orderItem);
            await context.SaveChangesAsync();

            var payload = new AddOrderItemPayload(orderItem);

            return payload;
        }
    }
}