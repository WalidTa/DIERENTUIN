using ZooManagement.Core.Entities;
using ZooManagement.Core.Enums;
using ZooManagement.Core.Interfaces;

namespace ZooManagement.Core.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public Category? GetById(int id)
        {
            return _categoryRepository.GetById(id);
        }

        public Category Create(Category category)
        {
            return _categoryRepository.Add(category);
        }

        public Category Update(Category category)
        {
            return _categoryRepository.Update(category);
        }

        public void Delete(int id)
        {
            _categoryRepository.Delete(id);
        }

    }
}
