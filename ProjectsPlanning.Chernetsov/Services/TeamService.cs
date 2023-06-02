using ProjectsPlanning.Chernetsov.Data;
using ProjectsPlanning.Chernetsov.Entities;

namespace ProjectsPlanning.Chernetsov.Services
{
    public class TeamService : ITeamService
    {
        private readonly ApplicationDbContext _context;

        public TeamService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Team> GetAllTeam()
        {
            return _context.Teams
                .Where(t => t.IsDeleted == false)
                .ToList();
        }
    }
}
