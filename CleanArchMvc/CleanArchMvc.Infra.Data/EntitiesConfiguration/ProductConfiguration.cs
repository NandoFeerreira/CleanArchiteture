using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Runtime.Serialization;
using System.Text.Json;

namespace CleanArchMvc.Infra.Data.EntitiesConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(200).IsRequired();

            builder.Property(p => p.Price).HasPrecision(10, 2);

            builder.HasOne(e => e.Category).WithMany(e => e.Products)
                .HasForeignKey(e => e.CategoryId);
        }

        private static string ConvertToDatabase(Product personalData)
        {
            return JsonSerializer.Serialize(personalData, default(JsonSerializerOptions));
        }

        private static Product ConvertFromDatabase(string jsonData)
        {
            var result = JsonSerializer.Deserialize<Product>(jsonData, default(JsonSerializerOptions));
            if (result == null)
            {
                throw new SerializationException("Unable to deserialize provided string");
            }
            return result;
        }
    }
}
