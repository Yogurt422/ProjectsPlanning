namespace ProjectsPlanning.Chernetsov.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DeadLine { get; set; }

        public int StatusId { get; set; }
        public int TaskTypeId { get; set; }

        public Status Status { get; set; }
        public TaskType TaskType { get; set; }
        public ICollection<PlanTask> PlanTasks { get; set; }
    }
}
