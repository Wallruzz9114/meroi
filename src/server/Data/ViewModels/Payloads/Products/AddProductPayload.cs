using System.Collections.Generic;
using Models.Abstractions;
using Models.Entities;

namespace Data.ViewModels.Payloads.Products
{
    public class AddProductPayload : BaseProductPayload
    {
        public AddProductPayload(Product product) : base(product) { }

        public AddProductPayload(IReadOnlyList<UserError> errors) : base(errors) { }
    }
}