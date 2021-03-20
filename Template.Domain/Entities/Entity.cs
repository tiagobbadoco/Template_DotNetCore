using System;
using System.ComponentModel.DataAnnotations;

namespace Template.Domain.Entities
{
    public class Entity
    {
        [Required]
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime? DateUpdated { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
