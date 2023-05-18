using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsPlanning.Chernetsov.Entities;

namespace ProjectsPlanning.Chernetsov.Configuration
{
    public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
          builder.HasKey(category  => category.Id)
                .HasName("PK_Categories_Id");

            builder.Property(category => category.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("nvarchar");

            builder.Property(category => category.Description)
                .IsRequired()
                .HasMaxLength(500)
                .HasColumnType("nvarchar");
        }
    }
}
