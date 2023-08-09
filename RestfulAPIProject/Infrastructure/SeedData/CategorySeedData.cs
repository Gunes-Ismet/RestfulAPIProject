using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestfulAPIProject.Models.Entities.Concrete;

namespace RestfulAPIProject.Infrastructure.SeedData
{
    public class CategorySeedData : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category { Id = 1, Name = "Kasap", Description = "Et ve Tavuk Ürünleri Bulunur!" },
                new Category { Id = 2, Name = "Manav", Description = "Meyve ve Sebzeler Bulunur!" },
                new Category { Id = 3, Name = "Şarküteri", Description = "Süt Ürünleri Bulunur!" }
                );
        }
    }
}
