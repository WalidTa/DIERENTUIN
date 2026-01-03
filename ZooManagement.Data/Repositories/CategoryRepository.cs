using ZooManagement.Core.Entities;
using ZooManagement.Core.Interfaces;
using ZooManagement.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ZooManagement.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ZooDbContext _context;

        public CategoryRepository(ZooDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetAll()
            => _context.Categories
                       .Include(c => c.Animals)
                       .ToList();

        public Category? GetById(int id)
            => _context.Categories
                       .Include(c => c.Animals)
                       .FirstOrDefault(c => c.Id == id);

        public Category Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category;
        }

        public Category Update(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
            return category;
        }

        public void Delete(int id)
        {
            var category = GetById(id);
            if (category == null) return;

            _context.Categories.Remove(category);
            _context.SaveChanges();
        }
    }
}
