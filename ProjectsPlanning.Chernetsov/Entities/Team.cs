namespace ProjectsPlanning.Chernetsov.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

        public int ProjectId { get; set; }

        public Project Project { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
