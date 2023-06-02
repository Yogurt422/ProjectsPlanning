namespace ProjectsPlanning.Chernetsov.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime DueDate { get; set; }

        public int CompanyId { get; set; }
        public int CategoryId { get; set; }
        public int StatusId { get; set; }
        public int PriorityId { get; set; }

        public Company Company { get; set; }
        public Category Category { get; set; }
        public Status Status { get; set; }
        public Priority Priority { get; set; }
        public Plan Plan { get; set; }

        public ICollection<Team> Teams { get; set; }
     

    }
}
