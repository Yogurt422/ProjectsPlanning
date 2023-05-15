namespace ProjectsPlanning.Chernetsov.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Experience { get; set; }

        public int PostId { get; set; }
        public int TeamId { get; set; }

        public Post Post { get; set; }
        public Team Team { get; set; }

    }
}
