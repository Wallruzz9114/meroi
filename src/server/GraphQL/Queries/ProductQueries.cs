using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.DataLoaders;
using Data;
using Data.Extensions;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace GraphQL.Queries
{
    [ExtendObjectType("Queries")]
    public class ProductQueries
    {
        [UseAppDbContext]
        public async Task<List<Product>> GetProductsAsync([ScopedService] AppDbContext context) =>
            await context.Products.ToListAsync();


        public async Task<Product> GetProductAsync(int id, ProductByIdDataLoader dataLoader, CancellationToken cancellationToken) =>
            await dataLoader.LoadAsync(id, cancellationToken);
    }
}