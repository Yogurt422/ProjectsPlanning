namespace ProjectsPlanning.Chernetsov.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

        public string Address { get; set; }
        public string Name { get; set; }

        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public ICollection<Project> Projects { get; set; }

    }
}
