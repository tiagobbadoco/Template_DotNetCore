using Microsoft.EntityFrameworkCore;
using System;
using Template.Domain.Entities;

namespace Template.Data.Extensions
{
    public static class ModelBuilderExtension
    {
        public static ModelBuilder SeedData(this ModelBuilder modelBuilder)
        {
            User administrador = new User { Id = Guid.NewGuid(), Name = "Administrador", Email = "admin@template.com", DateCreated = DateTime.Now, IsDeleted = false, Password = "Template" };

            Role admin = new Role { Id = Guid.NewGuid(), Name = "Administrador", DateCreated = DateTime.Now, IsDeleted = false };
            Role user = new Role { Id = Guid.NewGuid(), Name = "User", DateCreated = DateTime.Now, IsDeleted = false };

            modelBuilder.Entity<User>()
                .HasData(administrador);

            modelBuilder.Entity<Role>()
                .HasData(admin, user);

            modelBuilder.Entity<UserRole>()
                .HasData(new UserRole { Id = Guid.NewGuid(), UserId = administrador.Id, RoleId = admin.Id, DateCreated = DateTime.Now, IsDeleted = false });

            return modelBuilder;
        }
    }
}
