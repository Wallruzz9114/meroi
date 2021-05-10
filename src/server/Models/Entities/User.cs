using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Models.Abstractions;

namespace Models.Entities
{
    public class User : BaseEntity
    {
        [Required]
        [StringLength(200)]
        public string? Name { get; set; }

        [Required]
        [StringLength(200)]
        public string? Email { get; set; }

        public ICollection<UserOrder> UserOrders { get; set; } = new List<UserOrder>();
    }
}