using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Models.Abstractions;

namespace Models.Entities
{
    public class Order : BaseEntity
    {
        [Required]
        public DateTime? OrderDate { get; set; }

        public virtual ICollection<UserOrder> UserOrders { get; set; } = new List<UserOrder>();
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}