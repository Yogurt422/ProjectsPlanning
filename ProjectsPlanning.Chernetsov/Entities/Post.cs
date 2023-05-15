namespace ProjectsPlanning.Chernetsov.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Responsibilities { get; set; }

        public ICollection<Employee> Employees { get; set; }

    }
}
