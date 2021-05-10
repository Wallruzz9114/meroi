using System;
using System.ComponentModel.DataAnnotations;

namespace Models.Abstractions
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime LastAccessedAt { get; set; } = DateTime.UtcNow;
    }
}