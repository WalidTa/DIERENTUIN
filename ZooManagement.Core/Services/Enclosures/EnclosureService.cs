using ZooManagement.Core.Entities;
using ZooManagement.Core.Interfaces;

namespace ZooManagement.Core.Services.Enclosures
{
    public class EnclosureService : IEnclosureService
    {
        private readonly IEnclosureRepository _repository;

        public EnclosureService(IEnclosureRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Enclosure> GetAll()
            { 
                return _repository.GetAll(); 
            }

        public Enclosure? GetById(int id)
        {
            return _repository.GetById(id);
        }
        public Enclosure Create(Enclosure enclosure)
        {
            return _repository.Add(enclosure);
        }
             

        public Enclosure Update(Enclosure enclosure)
        {
            return _repository.Update(enclosure);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
