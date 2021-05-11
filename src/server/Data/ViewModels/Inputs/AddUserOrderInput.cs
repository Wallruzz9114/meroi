using System.Collections.Generic;
namespace Data.ViewModels.Inputs
{
    public record AddUserOrderInput(int UserId, IReadOnlyList<int> OrderIds);
}