namespace ProjectsPlanning.Chernetsov.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }

        public int StatusId { get; set; }
        public int TaskTypeId { get; set; }
        public int PriorityId { get; set; }

        public Status Status { get; set; }
        public TaskType TaskType { get; set; }
        public Priority Priority { get; set; }

        public ICollection<PlanTask> PlanTasks { get; set; }
    }
}
