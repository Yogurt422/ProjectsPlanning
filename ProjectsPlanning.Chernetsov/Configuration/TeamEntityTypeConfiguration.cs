using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsPlanning.Chernetsov.Entities;

namespace ProjectsPlanning.Chernetsov.Configuration
{
    public class TeamEntityTypeConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(tea => tea.Id)
                .HasName("PK_Teams_Id");

            builder.Property(tea => tea.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("nvarchar");
        }
    }
}
