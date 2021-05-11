using System.Threading.Tasks;
using Data;
using Data.Extensions;
using Data.ViewModels.Inputs;
using Data.ViewModels.Payloads.Products;
using HotChocolate;
using HotChocolate.Types;
using Models.Entities;

namespace GraphQL.Mutations
{
    [ExtendObjectType("Mutations")]
    public class ProductMutations
    {
        [UseAppDbContext]
        public async Task<AddProductPayload> AddProductAsync(AddProductInput input, [ScopedService] AppDbContext context)
        {
            var product = new Product
            {
                Name = input.Name,
                Price = input.Price,
                Type = input.Type,
                Description = input.Description,
                ImgUrl = input.ImgUrl
            };

            context.Products.Add(product);
            await context.SaveChangesAsync();

            var payload = new AddProductPayload(product);

            return payload;
        }
    }
}