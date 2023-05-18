using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsPlanning.Chernetsov.Entities;

namespace ProjectsPlanning.Chernetsov.Configuration
{
    public class StatusEntityTypeConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.HasKey(sta => sta.Id)
                .HasName("PK_Statuses_Id");

            builder.Property(sta => sta.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("nvarchar");

            builder.Property(sta => sta.Description)
                .IsRequired()
                .HasMaxLength(500)
                .HasColumnType("nvarchar");
        }
    }
}
