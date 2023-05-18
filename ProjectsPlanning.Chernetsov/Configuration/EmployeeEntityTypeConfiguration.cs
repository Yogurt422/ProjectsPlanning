using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsPlanning.Chernetsov.Entities;

namespace ProjectsPlanning.Chernetsov.Configuration
{
    public class EmployeeEntityTypeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(emp => emp.Id)
                .HasName("PK_Employees_Id");

            builder.Property(emp => emp.FirstName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("nvarchar");

            builder.Property(emp => emp.LastName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("nvarchar");

            builder.Property(emp => emp.Experience)
                .HasColumnType("integer");

            builder.HasOne(emp => emp.Post)
                .WithMany(p => p.Employees)
                .HasForeignKey(emp => emp.PostId)
                .HasConstraintName("FK_Employees_PostId_Posts_Id")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(emp => emp.Team)
                .WithMany(t => t.Employees)
                .HasForeignKey(emp => emp.TeamId)
                .HasConstraintName("FK_Employees_TeamId_Teams_Id")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(emp => emp.Company)
                .WithOne(c => c.Employee)
                .HasForeignKey<Company>(emp => emp.EmployeeId)
                .HasConstraintName("FK_Companies_EmployeeId_Companies_Id")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
