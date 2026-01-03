using ZooManagement.Core.Entities;

namespace ZooManagement.Core.Interfaces
{
    public interface IAnimalRepository
    {
        IEnumerable<Animal> GetAll();
        Animal? GetById(int id);
        Animal Add(Animal animal);
        Animal Update(Animal animal);
        void Delete(int id);
    }
}
