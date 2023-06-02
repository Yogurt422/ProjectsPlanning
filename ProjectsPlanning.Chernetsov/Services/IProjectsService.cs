using ProjectsPlanning.Chernetsov.Entities;

namespace ProjectsPlanning.Chernetsov.Services
{
    public interface IProjectsService
    {
        public void AddProject(Project newProject);
        public Project GetProject(string projectName);
        public void UpdateProject(string projectName, Project newProject);
        public void DeleteProject(string projectName);
    }
}
