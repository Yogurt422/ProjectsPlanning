namespace ProjectsPlanning.Chernetsov.Entities
{
    public class Plan
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

        public string Description { get; set; }

        public int ProjectId { get; set; }

        public Project Project { get; set; }

        public ICollection<PlanTask> PlanTasks { get; set; }

    }
}
