using System;
using System.Collections.Generic;
using HotChocolate.Types.Relay;
using Models.Entities;

namespace Data.ViewModels.Inputs
{
    public record AddUserOrderInput([ID(nameof(User))] int UserId, [ID(nameof(Order))] IReadOnlyList<int> OrderIds);
}