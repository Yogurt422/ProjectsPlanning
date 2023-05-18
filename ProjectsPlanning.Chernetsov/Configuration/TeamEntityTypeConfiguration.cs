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

            builder.HasOne(tea => tea.Project)
                .WithMany(p => p.Teams)
                .HasForeignKey(tea => tea.ProjectId)
                .HasConstraintName("FK_Teams_ProjectId_Projects_Id")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
