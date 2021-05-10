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

        public ICollection<UserOrder> UserOrders { get; set; } = new List<UserOrder>();
    }
}