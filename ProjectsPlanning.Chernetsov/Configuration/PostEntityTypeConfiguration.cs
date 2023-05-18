using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsPlanning.Chernetsov.Entities;

namespace ProjectsPlanning.Chernetsov.Configuration
{
    public class PostEntityTypeConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(pos => pos.Id)
                .HasName("PK_Posts_Id");

            builder.Property(pos => pos.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("nvarchar");

            builder.Property(pos => pos.Description)
                .IsRequired()
                .HasMaxLength(500)
                .HasColumnType("nvarchar");

            builder.Property(pos => pos.Responsibilities)
                .IsRequired()
                .HasMaxLength(500)
                .HasColumnType("nvarchar");
        }
    }
}
