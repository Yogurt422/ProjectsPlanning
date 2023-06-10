using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectsPlanning.Chernetsov.Entities;

namespace ProjectsPlanning.Chernetsov.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
               
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Category> Categories { get; set; }
        //public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<PlanTask> PlanTasks { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Entities.Task> Tasks { get; set; }
        public DbSet<TaskType> TaskTypes { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }
    }

}
