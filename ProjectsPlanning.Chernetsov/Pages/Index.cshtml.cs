﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualBasic;
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
        private readonly IStatusService _statusService;
        private readonly ITeamService _teamService;
        private readonly IPriorityService _priorityService;
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public InputProject InputProject { get; set; }

        public InputCategory InputCategory { get; set; }


        public List<SelectListItem> CategoryItems { get; set; }
        public List<SelectListItem> PriorityItems { get; set; }
        public List<SelectListItem> TeamItems { get; set; }
        public List<SelectListItem> StatusItems { get; set; }

        [BindProperty]
        public IEnumerable<Project> ProjectsIdOne { get; set; }

        [BindProperty]
        public IEnumerable<Project> ProjectsIdTwo { get; set; }

        [BindProperty]
        public IEnumerable<Project> ProjectsIdThree { get; set; }

        public Project Project { get; set; }                  


        public IndexModel(ILogger<IndexModel> logger, 
            IProjectsService projectsService, 
            ICategoryService categoryService, 
            ITeamService teamService,
            IPriorityService priorityService,
            IStatusService statusService,
            ApplicationDbContext context)

        {
            _logger = logger;
            _projectsService = projectsService;
            _categoryService = categoryService;
            _teamService = teamService;
            _priorityService = priorityService;
            _statusService = statusService;
            _context = context;
            LoadTeams();
            LoadCategory();
            LoadPriority();
            LoadStatus();

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
        private void LoadStatus()
        {
            List<Status> statuses = _statusService.GetAllStatus();
            StatusItems = statuses.Select(pr => new SelectListItem
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
                return RedirectToPage("Index");
            var status = _context.Statuses.Where(st => st.Id == 1 && st.IsDeleted == false).FirstOrDefault();
            var project = new Project()
            
            {
                Name = InputProject.Name,
                CreateDate = DateTime.Now,
                DueDate = InputProject.DueDate,
                CategoryId = InputProject.SelectedValueCategory,
                Description = InputProject.Description,
                StatusId = status.Id,
                PriorityId = InputProject.SelectedValuePriority,
                TeamId = InputProject.SelectedValueTeam
            };
            _projectsService.AddProject(project);

            ProjectsIdOne = _projectsService.GetProjectsSortIdOne();

            return RedirectToPage("Index");
        }

        public PartialViewResult OnPostReceiveProject(int id)
        {
            Project = _projectsService.GetProjectById(id);


            var editProject = new EditProject()
            {
                Id = id,
                Name = Project.Name,
                DueDate = Project.DueDate,
                Description = Project.Description,
                CategoryId = Project.CategoryId,
                StatusId = Project.StatusId,
                PriorityId = Project.PriorityId,
                TeamId = Project.TeamId,
                Category = Project.Category,
                Status = Project.Status,
                Priority = Project.Priority,
                Team= Project.Team,
                EditCategoryItems = CategoryItems,
                EditPriorityItems = PriorityItems,
                EditTeamItems = TeamItems,
                EditStatusItems = StatusItems,
               

            };
            
            return Partial("_EditProject", editProject);
        }

        public IActionResult OnPostEditProject(int id,EditProject editProject)
        {

            var project = new Project()
            {
                Name = editProject.Name,
                DueDate = editProject.DueDate,
                Description = editProject.Description,
                CategoryId = editProject.SelectedValueCategory,
                StatusId = editProject.SelectedValueStatus,
                PriorityId = editProject.SelectedValuePriority,
                TeamId = editProject.SelectedValueTeam
            };

            _projectsService.UpdateProject(id,project);

            return RedirectToPage("Index");
        }

        public IActionResult OnPostReturnPartialDeleteProject(int id)
        {
            return Partial("_DeleteProject", id);
        }

        public IActionResult OnPostDeleteProject(int id)
        {
            _projectsService.DeleteProject(id);
            return RedirectToPage("Index");
        }
        public IActionResult OnPostAddCategory(InputCategory inputCategory)
        {
            var category = new Category()
            {
                Name = inputCategory.Name,
                Description = inputCategory.Description,
            };
            _categoryService.AddCategory(category);

            return RedirectToPage("Index");
        }
    }
}