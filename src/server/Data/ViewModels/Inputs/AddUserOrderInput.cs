using System;
using System.Collections.Generic;
using HotChocolate.Types.Relay;
using Models.Entities;

namespace Data.ViewModels.Inputs
{
    public record AddUserOrderInput([ID(nameof(User))] Guid UserId, [ID(nameof(Order))] IReadOnlyList<Guid> OrderIds);
}