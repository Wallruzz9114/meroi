using System.ComponentModel.DataAnnotations;
using Models.Abstractions;

namespace Models.Entities
{
    public class OrderItem : BaseEntity
    {
        public int OrderId { get; set; }
        public Order? Order { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }

        [Required]
        public int? Count { get; set; }
    }
}