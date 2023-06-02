using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsPlanning.Chernetsov.Entities;

namespace ProjectsPlanning.Chernetsov.Configuration
{
    public class PriorityEntityTypeConfiguration : IEntityTypeConfiguration<Priority>
    {
        public void Configure(EntityTypeBuilder<Priority> builder)
        {
            builder.HasKey(priority => priority.Id)
                .HasName("PK_Priorities_Id");

            builder.Property(priority => priority.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("nvarchar");

            builder.Property(priority => priority.Description)
                .IsRequired()
                .HasMaxLength(500)
                .HasColumnType("nvarchar");
        }
    }
}
