using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestfulAPIProject.Models.Entities.Concrete;

namespace RestfulAPIProject.Infrastructure.SeedData
{
    public class AppUserSeedData : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasData(
                new AppUser { Id = 1, UserName = "test1", Password = "123456" },
                new AppUser { Id = 2, UserName = "test2", Password = "123456" },
                new AppUser { Id = 3, UserName = "test3", Password = "123456" },
                new AppUser { Id = 4, UserName = "test4", Password = "123456" }
                );
        }
    }
}
