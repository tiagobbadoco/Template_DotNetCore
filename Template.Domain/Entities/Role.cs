using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Template.Domain.Entities
{
    public class Role : Entity
    {
        [Required]
        public string Name { get; set; }
        [NotMapped]
        public List<User> Users { get; set; }
    }
}
