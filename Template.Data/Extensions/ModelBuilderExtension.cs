using Microsoft.EntityFrameworkCore;
using System;
using Template.Domain.Entities;

namespace Template.Data.Extensions
{
    public static class ModelBuilderExtension
    {
        public static ModelBuilder SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasData(
                    new User { Id = Guid.NewGuid(), Name = "Administrador", Email = "admin@template.com", DateCreated = DateTime.Now, IsDeleted = false, Password = "Template" });

            return modelBuilder;
        }
    }
}
