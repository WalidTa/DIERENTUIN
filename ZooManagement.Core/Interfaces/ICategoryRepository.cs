using ZooManagement.Core.Entities;

namespace ZooManagement.Core.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        Category? GetById(int id);
        Category Add(Category category);
        Category Update(Category category);
        void Delete(int id);
    }
}
