using System;
using System.ComponentModel.DataAnnotations;
using Models.Abstractions;

namespace Models.Entities
{
    public class Order : BaseEntity
    {
        [Required]
        public DateTime? OrderDate { get; set; }
    }
}