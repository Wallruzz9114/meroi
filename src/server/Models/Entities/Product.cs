using System.ComponentModel.DataAnnotations;
using Models.Abstractions;

namespace Models.Entities
{
    public class Product : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        [Required]
        public float? Price { get; set; }
    }
}