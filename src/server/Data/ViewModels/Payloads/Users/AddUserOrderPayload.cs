using Models.Abstractions;
using Models.Entities;

namespace Data.ViewModels.Payloads.Users
{
    public class AddUserOrderPayload : BasePayload
    {
        public AddUserOrderPayload(User user)
        {
            User = user;
        }

        public AddUserOrderPayload(UserError error) : base(new[] { error }) { }

        public User? User { get; init; }
    }
}