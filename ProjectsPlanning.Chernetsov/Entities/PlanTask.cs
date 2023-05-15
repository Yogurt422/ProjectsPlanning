namespace ProjectsPlanning.Chernetsov.Entities
{
    public class PlanTask
    {
        public int PlanId { get; set; }
        public int ProjectTaskId { get; set; }
        public int Order { get; set; }

        public Plan Plan { get; set; }
        public Task ProjectTask { get; set; }
    }
}
