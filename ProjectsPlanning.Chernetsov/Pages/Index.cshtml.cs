using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        [BindProperty]
        public InputProject InputProject { get; set; }
        public List<SelectListItem> CategoryItems { get; set; }
        public List<SelectListItem> PriorityItems { get; set; }
        public List<SelectListItem> TeamItems { get; set; }
        

        public IndexModel(ILogger<IndexModel> logger, IProjectsService projectsService, ICategoryService categoryService, ITeamService teamService)

        {
            _logger = logger;
            _projectsService = projectsService;
            _categoryService = categoryService;
            _teamService = teamService;
            LoadTeams();
        }
        private void LoadTeams()
        {
            List<Team> teams = _teamService.GetAllTeam();
            TeamItems = teams.Select(t => new SelectListItem
            {
                Value = "1",
                Text = t.Name
            })
           .ToList();
            TeamItems.Insert(0, new SelectListItem { Value = "0", Text = "Отсутствует" });
        }

        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            var project = new Project
            {
                Name = InputProject.Name,
            };
            // Из класса InputProject добавить данные в переменную Project и вызвать из сервиса метод Add
            return Page();
        }
    }
}