 using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsPlanning.Chernetsov.Entities;

namespace ProjectsPlanning.Chernetsov.Configuration
{
    public class ProjectEntityTypeConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(project => project.Id)
                .HasName("PK_Projects_Id");

            builder.Property(project => project.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("nvarchar");

            builder.Property(project => project.CreateDate)
                .HasColumnType("date");

            builder.Property(project => project.DueDate)
                .HasColumnType("date");

            builder.HasOne(project => project.Company)
                .WithMany(c => c.Projects)
                .HasForeignKey(project => project.CompanyId)
                .HasConstraintName("FK_Projects_CompanyId_Companies_Id")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(project => project.Category)
                .WithMany(c => c.Projects)
                .HasForeignKey(project => project.CategoryId)
                .HasConstraintName("FK_Projects_CategoryId_Categories_Id")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(project => project.Priority)
                .WithMany(priority => priority.Projects)
                .HasForeignKey(project => project.PriorityId)
                .HasConstraintName("FK_Projects_PriorityId_Priorities_Id")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(project => project.Status)
                .WithMany(s  => s.Projects)
                .HasForeignKey(project => project.StatusId)
                .HasConstraintName("FK_Projects_StatusId_Statuses_Id")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(project => project.Plan)
                .WithOne(plan => plan.Project)
                .HasForeignKey<Plan>(project => project.ProjectId)
                .HasConstraintName("FK_Projects_PlanId_Plans_Id")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
