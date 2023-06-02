﻿using ProjectsPlanning.Chernetsov.Data;
using ProjectsPlanning.Chernetsov.Entities;

namespace ProjectsPlanning.Chernetsov.Services
{
    public class ProjectsService : IProjectsService
    {
        private readonly ApplicationDbContext _context;
        public ProjectsService(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddProject(Project newProject)
        {
            _context.Projects.Add(newProject);
            _context.SaveChanges();
        }

        public void DeleteProject(string projectName)
        {
            var project = _context.Projects
                .Where(p => p.Name == projectName)
                .FirstOrDefault();
            project.IsDeleted = true;
            _context.SaveChanges();
        }

        public Project GetProject(string projectName)
        {
            return _context.Projects
                .Where(p => p.Name == projectName && p.IsDeleted == false)
                .FirstOrDefault();
        }


        public void UpdateProject(string projectName, Project newProject)
        {
            var project = _context.Projects
                .Where(p => p.Name == projectName && p.IsDeleted == false)
                .FirstOrDefault();
            project = newProject;
            _context.SaveChanges();
        }
    }
}