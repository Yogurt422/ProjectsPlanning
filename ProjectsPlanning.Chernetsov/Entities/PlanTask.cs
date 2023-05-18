namespace ProjectsPlanning.Chernetsov.Entities
{
    public class PlanTask
    {
        public int PlanId { get; set; }
        public int TaskId { get; set; }

        public int Order { get; set; }

        public Plan Plan { get; set; }
        public Task Task { get; set; }
    }
}
