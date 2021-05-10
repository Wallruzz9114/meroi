using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Extensions
{
    public static class ObjectFieldDescriptorExtensions
    {
        public static IObjectFieldDescriptor UseAppDbContext<TDbContext>(this IObjectFieldDescriptor descriptor) where TDbContext : DbContext
        {
            return descriptor.UseScopedService(
                create: s => s.GetRequiredService<IDbContextFactory<TDbContext>>().CreateDbContext(), disposeAsync: (_, c) => c.DisposeAsync()
            );
        }
    }
}