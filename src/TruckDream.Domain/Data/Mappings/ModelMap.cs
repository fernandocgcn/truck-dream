using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TruckDream.Domain.Entities;

namespace TruckDream.Domain.Data.Mappings
{
    internal class ModelMap : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.ToTable("tb_model");

            // columns
            builder.Property(entity => entity.Id)
                .HasColumnName("model_id")
                .ValueGeneratedNever()
                .IsRequired();
            builder.Property(entity => entity.Acronym)
                .HasColumnName("acronym")
                .IsRequired();
            builder.Property(entity => entity.Name)
                .HasColumnName("name")
                .IsRequired();

            // primary key
            builder.HasKey(entity => entity.Id);

            // initial db seed
            builder.Seed();
        }
    }
}
