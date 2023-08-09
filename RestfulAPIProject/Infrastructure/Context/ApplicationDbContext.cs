using Microsoft.EntityFrameworkCore;
using RestfulAPIProject.Infrastructure.SeedData;
using RestfulAPIProject.Models.Entities.Concrete;

namespace RestfulAPIProject.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<AppUser> AppUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategorySeedData());
            modelBuilder.ApplyConfiguration(new AppUserSeedData());

            base.OnModelCreating(modelBuilder);
        }
    }
}
