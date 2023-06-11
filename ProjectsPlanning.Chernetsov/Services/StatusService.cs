using ProjectsPlanning.Chernetsov.Data;
using ProjectsPlanning.Chernetsov.Entities;

namespace ProjectsPlanning.Chernetsov.Services
{
    public class StatusService : IStatusService
    {
        private readonly ApplicationDbContext _context;

        public StatusService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Status> GetAllStatus()
        {
            return _context.Statuses
                .Where(st => st.IsDeleted == false)
                .ToList();
        }
    }
}
