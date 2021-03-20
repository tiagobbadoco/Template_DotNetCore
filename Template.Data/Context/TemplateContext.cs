using Microsoft.EntityFrameworkCore;
using Template.Data.Extensions;
using Template.Domain.Entities;

namespace Template.Data.Context
{
    public class TemplateContext  : DbContext
    {
        public TemplateContext(DbContextOptions<TemplateContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedData();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
    }
}
