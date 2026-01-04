using Microsoft.EntityFrameworkCore;
using ZooManagement.Core.Entities;
using ZooManagement.Core.Interfaces;
using ZooManagement.Data.Context;

namespace ZooManagement.Data.Repositories
{
    public class EnclosureRepository : IEnclosureRepository
    {
        private readonly ZooDbContext _context;

        public EnclosureRepository(ZooDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Enclosure> GetAll()
            => _context.Enclosures
                       .Include(e => e.Animals)
                       .ToList();

        public Enclosure? GetById(int id)
            => _context.Enclosures
                       .Include(e => e.Animals)
                       .FirstOrDefault(e => e.Id == id);

        public Enclosure Add(Enclosure enclosure)
        {
            _context.Enclosures.Add(enclosure);
            _context.SaveChanges();
            return enclosure;
        }

        public Enclosure Update(Enclosure enclosure)
        {
            _context.Enclosures.Update(enclosure);
            _context.SaveChanges();
            return enclosure;
        }

        public void Delete(int id)
        {
            var enclosure = GetById(id);
            if (enclosure == null) return;

            _context.Enclosures.Remove(enclosure);
            _context.SaveChanges();
        }
    }
}
