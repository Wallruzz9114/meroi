using System.Collections.Generic;

namespace Data.ViewModels
{
    public class CurrentUser
    {
        public string? UserId { get; set; }
        public List<string>? Claims { get; set; }
    }
}