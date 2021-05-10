using System.Collections.Generic;
using Models.Abstractions;
using Models.Entities;

namespace Data.ViewModels.Payloads.Users
{
    public class AddUserPayload : BaseUserPayload
    {
        public AddUserPayload(User user) : base(user) { }
        public AddUserPayload(IReadOnlyList<UserError> errors) : base(errors) { }
    }
}