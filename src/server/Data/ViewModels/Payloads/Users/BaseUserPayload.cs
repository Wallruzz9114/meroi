using System.Collections.Generic;
using Models.Abstractions;
using Models.Entities;

namespace Data.ViewModels.Payloads.Users
{
    public class BaseUserPayload : BasePayload
    {
        protected BaseUserPayload(User user)
        {
            User = user;
        }

        protected BaseUserPayload(IReadOnlyList<UserError> errors) : base(errors) { }

        public User? User { get; init; }
    }
}