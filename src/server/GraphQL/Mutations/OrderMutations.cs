using System.Threading.Tasks;
using Data;
using Data.Extensions;
using Data.ViewModels.Inputs;
using Data.ViewModels.Payloads;
using HotChocolate;
using HotChocolate.Types;
using Models.Entities;

namespace GraphQL.Mutations
{
    [ExtendObjectType("Mutations")]
    public class OrderMutations
    {
        [UseAppDbContext]
        public async Task<AddOrderPayload> AddOrderAsync(AddOrderInput input, [ScopedService] AppDbContext context)
        {
            var newOrder = new Order
            {
                OrderDate = input.OrderDate
            };

            context.Orders.Add(newOrder);
            await context.SaveChangesAsync();

            var payload = new AddOrderPayload(newOrder);

            return payload;
        }
    }
}