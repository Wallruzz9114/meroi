using HotChocolate.Types;
using Models.Entities;

namespace Data.ViewModels.Types
{
    public class UserType : ObjectType<User>
    {
        protected override void Configure(IObjectTypeDescriptor<User> descriptor)
        {
            descriptor.Description("Represents a User entity.");
            descriptor
                .Field(p => p.Id)
                .Description("Represents the user's id.");
            descriptor
                .Field(p => p.Name)
                .Description("Represents the user's name.");
            descriptor
                .Field(p => p.Email)
                .Description("Represents the user's email.");
            descriptor.Field(p => p.CreatedAt).Ignore();
            descriptor.Field(p => p.UpdatedAt).Ignore();
            descriptor.Field(p => p.LastAccessedAt).Ignore();
        }
    }
}