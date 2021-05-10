using System.Collections.Generic;
using Models.Abstractions;
using Models.Entities;

namespace Data.ViewModels.Payloads.OrderItems
{
    public class OrderItemPayloadBase : BasePayload
    {
        protected OrderItemPayloadBase(OrderItem orderItem)
        {
            OrderItem = orderItem;
        }

        protected OrderItemPayloadBase(IReadOnlyList<UserError> errors) : base(errors) { }

        public OrderItem? OrderItem { get; init; }
    }
}