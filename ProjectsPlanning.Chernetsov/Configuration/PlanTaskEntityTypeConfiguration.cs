using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsPlanning.Chernetsov.Entities;

namespace ProjectsPlanning.Chernetsov.Configuration
{
    public class PlanTaskEntityTypeConfiguration : IEntityTypeConfiguration<PlanTask>
    {
        public void Configure(EntityTypeBuilder<PlanTask> builder)
        {
            builder.HasKey(pt => new { pt.PlanId, pt.TaskId })
                .HasName("PK_PlanTasks_PlanId_ProjectTaskId");

            builder.Property(pt => pt.Order)
                .IsRequired()
                .HasColumnType("integer");

            builder.HasOne(pt => pt.Plan)
                .WithMany(p => p.PlanTasks)
                .HasForeignKey(pt => pt.PlanId)
                .HasConstraintName("FK_PlanTasks_PlanId_Plan_Id")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(pt => pt.Task)
                .WithMany(t => t.PlanTasks)
                .HasForeignKey(pt => pt.TaskId)
                .HasConstraintName("FK_PlanTasks_TaskId_Task_Id")
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
