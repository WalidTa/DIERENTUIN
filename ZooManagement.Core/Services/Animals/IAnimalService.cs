using ZooManagement.Core.Entities;

namespace ZooManagement.Core.Services.Animals
{
    public interface IAnimalService
    {
        // CRUD
        IEnumerable<Animal> GetAll();
        Animal? GetById(int id);
        Animal Create(Animal animal);
        Animal Update(Animal animal);
        void Delete(int id);

        // Actions
        void Sunrise(int animalId);
        void Sunset(int animalId);
        string FeedingTime(int animalId);
        IEnumerable<string> CheckConstraints(int animalId);
    }
}
