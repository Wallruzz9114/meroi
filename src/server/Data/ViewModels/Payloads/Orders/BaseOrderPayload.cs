using System.Collections.Generic;
using Models.Abstractions;
using Models.Entities;

namespace Data.ViewModels.Payloads.Orders
{
    public class BaseOrderPayload : BasePayload
    {
        protected BaseOrderPayload(Order order)
        {
            Order = order;
        }

        protected BaseOrderPayload(IReadOnlyList<UserError> errors) : base(errors) { }

        public Order? Order { get; init; }
    }
}