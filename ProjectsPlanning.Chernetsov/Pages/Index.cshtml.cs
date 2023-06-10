using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectsPlanning.Chernetsov.Data;
using ProjectsPlanning.Chernetsov.Entities;
using ProjectsPlanning.Chernetsov.Entities.DTO;
using ProjectsPlanning.Chernetsov.Services;

namespace ProjectsPlanning.Chernetsov.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IProjectsService _projectsService;
        private readonly ICategoryService _categoryService;
        private readonly ITeamService _teamService;
        private readonly IPriorityService _priorityService;
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public InputProject InputProject { get; set; }
        public List<SelectListItem> CategoryItems { get; set; }
        public List<SelectListItem> PriorityItems { get; set; }
        public List<SelectListItem> TeamItems { get; set; }

        [BindProperty]
        public IEnumerable<Project> ProjectsIdOne { get; set; }

        [BindProperty]
        public IEnumerable<Project> ProjectsIdTwo { get; set; }

        [BindProperty]
        public IEnumerable<Project> ProjectsIdThree { get; set; }
        

        public IndexModel(ILogger<IndexModel> logger, 
            IProjectsService projectsService, 
            ICategoryService categoryService, 
            ITeamService teamService,
            IPriorityService priorityService,
            ApplicationDbContext context)

        {
            _logger = logger;
            _projectsService = projectsService;
            _categoryService = categoryService;
            _teamService = teamService;
            _priorityService = priorityService;
            _context = context;
            LoadTeams();
            LoadCategory();
            LoadPriority();
        }
        private void LoadTeams()
        {
            List<Team> teams = _teamService.GetAllTeam();
            TeamItems = teams.Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = t.Name
            })
           .ToList();

        }
        private void LoadCategory()
        {
            List<Category> categories = _categoryService.GetAllCategory();
            CategoryItems = categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            })
           .ToList();

        }

   

        private void LoadPriority()
        {
            List<Priority> priorities = _priorityService.GetAllPriority();
            PriorityItems = priorities.Select(pr => new SelectListItem
            {
                Value = pr.Id.ToString(),
                Text = pr.Name
            })
           .ToList();

        }

        public void OnGet()
        {
            ProjectsIdOne = _projectsService.GetProjectsSortIdOne();
            ProjectsIdTwo = _projectsService.GetProjectsSortIdTwo();
            ProjectsIdThree = _projectsService.GetProjectsSortIdThree();
            
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();
            var status = _context.Statuses.Where(st => st.Id == 1 && st.IsDeleted == false).FirstOrDefault();
            var project = new Project()
            
            {
                Name = InputProject.Name,
                CreateDate = DateTime.Now,
                DueDate = InputProject.DueDate,
                CategoryId = InputProject.SelectedValueCategory,
                StatusId = status.Id,
                PriorityId = InputProject.SelectedValuePriority,
                TeamId = InputProject.SelectedValueTeam
            };
            _projectsService.AddProject(project); 
            return RedirectToPage("Index");
        }
    }
}