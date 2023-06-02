using ProjectsPlanning.Chernetsov.Data;
using ProjectsPlanning.Chernetsov.Entities;
using System.Reflection.Metadata.Ecma335;

namespace ProjectsPlanning.Chernetsov.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;
        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddCategory(Category newCategory)
        {
            _context.Categories.Add(newCategory);
            _context.SaveChanges();
        }

        public List<Category> GetAllCategory()
        {
            return _context.Categories
                .Where(c => c.IsDeleted == false)
                .ToList();
            
        }
    }
}
