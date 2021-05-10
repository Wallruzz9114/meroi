using System.Collections.Generic;
using Models.Abstractions;
using Models.Entities;

namespace Data.ViewModels.Payloads.Products
{
    public class BaseProductPayload : BasePayload
    {
        protected BaseProductPayload(Product product)
        {
            Product = product;
        }

        protected BaseProductPayload(IReadOnlyList<UserError> errors) : base(errors) { }

        public Product? Product { get; init; }
    }
}