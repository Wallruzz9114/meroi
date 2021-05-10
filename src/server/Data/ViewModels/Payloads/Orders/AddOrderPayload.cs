using System.Collections.Generic;
using Data.ViewModels.Payloads.Orders;
using Models.Abstractions;
using Models.Entities;

namespace Data.ViewModels.Payloads
{
    public class AddOrderPayload : BaseOrderPayload
    {
        public AddOrderPayload(Order order) : base(order) { }

        public AddOrderPayload(IReadOnlyList<UserError> errors) : base(errors) { }
    }
}