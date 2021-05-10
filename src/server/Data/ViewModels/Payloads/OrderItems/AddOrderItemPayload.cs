using System.Collections.Generic;
using Models.Abstractions;
using Models.Entities;

namespace Data.ViewModels.Payloads.OrderItems
{
    public class AddOrderItemPayload : OrderItemPayloadBase
    {
        public AddOrderItemPayload(OrderItem orderItem) : base(orderItem) { }

        public AddOrderItemPayload(IReadOnlyList<UserError> errors) : base(errors) { }
    }
}