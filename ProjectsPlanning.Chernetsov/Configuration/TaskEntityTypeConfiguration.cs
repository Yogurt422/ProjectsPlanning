using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsPlanning.Chernetsov.Entities;

namespace ProjectsPlanning.Chernetsov.Configuration
{
    public class TaskEntityTypeConfiguration : IEntityTypeConfiguration<Entities.Task>
    {

        public void Configure(EntityTypeBuilder<Entities.Task> builder)
        {
            builder.HasKey(task => task.Id)
                .HasName("PK_Tasks_Id");

            builder.Property(task => task.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("nvarchar");

            builder.Property(task => task.Description)
                .IsRequired()
                .HasMaxLength(500)
                .HasColumnType("nvarchar");

            builder.Property(task => task.DeadLine)
                .HasColumnType("date");

            builder.HasOne(task => task.Status)
                .WithMany(s => s.Tasks)
                .HasForeignKey(task => task.StatusId)
                .HasConstraintName("FK_Tasks_StatusId_Statuses_Id")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(task => task.TaskType)
                .WithMany(tt => tt.Tasks)
                .HasForeignKey(task => task.TaskTypeId)
                .HasConstraintName("FK_Tasks_TaskTypeId_TaskTypes_Id")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
