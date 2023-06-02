using ProjectsPlanning.Chernetsov.Entities;

namespace ProjectsPlanning.Chernetsov.Services
{
    public interface ICategoryService
    {

        public void AddCategory(Category newCategory);
        public List<Category> GetAllCategory();
    }
}
