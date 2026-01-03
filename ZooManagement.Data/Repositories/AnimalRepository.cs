using ZooManagement.Core.Entities;
using ZooManagement.Core.Interfaces;
using ZooManagement.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ZooManagement.Data.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly ZooDbContext _context;

        public AnimalRepository(ZooDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Animal> GetAll()
            => _context.Animals
                       .Include(a => a.Enclosure)
                       .Include(a => a.Prey)
                       .ToList();

        public Animal? GetById(int id)
            => _context.Animals
                       .Include(a => a.Enclosure)
                       .Include(a => a.Prey)
                       .FirstOrDefault(a => a.Id == id);

        public Animal Add(Animal animal)
        {
            _context.Animals.Add(animal);
            _context.SaveChanges();
            return animal;
        }

        public Animal Update(Animal animal)
        {
            _context.Animals.Update(animal);
            _context.SaveChanges();
            return animal;
        }

        public void Delete(int id)
        {
            var animal = GetById(id);
            if (animal == null) return;

            _context.Animals.Remove(animal);
            _context.SaveChanges();
        }
    }
}
