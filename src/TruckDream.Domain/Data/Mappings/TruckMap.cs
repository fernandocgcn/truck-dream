using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TruckDream.Domain.Entities;

namespace TruckDream.Domain.Data.Mappings
{
    internal class TruckMap : IEntityTypeConfiguration<Truck>
    {
        public void Configure(EntityTypeBuilder<Truck> builder)
        {
            builder.ToTable("tb_truck");

            // columns
            builder.Property(entity => entity.Id)
                .HasColumnName("truck_id")
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(entity => entity.ProductionYear)
                .HasColumnName("production_year")
                .ValueGeneratedNever()
                .IsRequired();
            builder.Property(entity => entity.ModelYear)
                .HasColumnName("model_year")
                .ValueGeneratedNever()
                .IsRequired();
            builder.Property(entity => entity.Color)
                .HasColumnName("color")
                .IsRequired(false);
            builder.Property(entity => entity.Horsepower)
                .HasColumnName("horsepower")
                .ValueGeneratedNever()
                .IsRequired(false);
            builder.Property(entity => entity.Mileage)
                .HasColumnName("mileage")
                .IsRequired(false);

            // primary key
            builder.HasKey(entity => entity.Id);

            // relationship
            builder.HasOne(entity => entity.Model)
                .WithMany()
                .HasForeignKey("model_id")
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}
