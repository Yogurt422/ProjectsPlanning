using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsPlanning.Chernetsov.Entities;

namespace ProjectsPlanning.Chernetsov.Configuration
{
    public class PlanEntityTypeConfiguration : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder.HasKey(plan => plan.Id)
                .HasName("PK_Plans_Id");

            builder.Property(plan => plan.Description)
                .IsRequired()
                .HasMaxLength(500)
                .HasColumnType("nvarchar");
        }
    }
}
