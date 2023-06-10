using ProjectsPlanning.Chernetsov.Data;
using ProjectsPlanning.Chernetsov.Entities;

namespace ProjectsPlanning.Chernetsov.Services
{
    public class PriorityService : IPriorityService
    {
        private readonly ApplicationDbContext _context;

        public PriorityService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Priority> GetAllPriority()
        {
           return _context.Priorities
                .Where(pr => pr.IsDeleted == false)
                .ToList();
        }
    }
}
