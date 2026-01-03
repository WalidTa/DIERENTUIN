using ZooManagement.Core.Entities;

namespace ZooManagement.Core.Services.Categories
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAll();
        Category? GetById(int id);
        Category Create(Category category);
        Category Update(Category category);
        void Delete(int id);
    }
}
