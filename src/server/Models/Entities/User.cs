using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Models.Abstractions;

namespace Models.Entities
{
    public class User : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string? Name { get; set; }

        [Required]
        [StringLength(100)]
        public string? Email { get; set; }

        public virtual ICollection<UserOrder> UserOrders { get; set; } = new List<UserOrder>();
    }
}