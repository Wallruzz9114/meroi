using System.Reflection;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;

namespace Data.Extensions
{
    public class UseAppDbContextAttribute : ObjectFieldDescriptorAttribute
    {
        public override void OnConfigure(IDescriptorContext context, IObjectFieldDescriptor descriptor, MemberInfo member)
        {
            descriptor.UseAppDbContext<AppDbContext>();
        }
    }
}