using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Template.Domain.Entities
{
    public class UserRole : Entity
    {
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public User User { get; set; }
        [ForeignKey(nameof(Role))]
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
    }
}
