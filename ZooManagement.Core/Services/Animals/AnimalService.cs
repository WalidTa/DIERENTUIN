using ZooManagement.Core.Entities;
using ZooManagement.Core.Enums;
using ZooManagement.Core.Interfaces;

namespace ZooManagement.Core.Services.Animals
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _repository;

        public AnimalService(IAnimalRepository repository)
        {
            _repository = repository;
        }

        // CRUD
        public IEnumerable<Animal> GetAll()
        {
            return _repository.GetAll();
        }

        public Animal? GetById(int id)
        {
            return _repository.GetById(id);
        }

        public Animal Create(Animal animal)
        {
            return _repository.Add(animal);
        }

        public Animal Update(Animal animal)
        {
            return _repository.Update(animal);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        // Actions
        public void Sunrise(int animalId)
        {
            var animal = GetById(animalId);
            if (animal == null) return;

            animal.IsAwake = animal.ActivityPattern != ActivityPattern.Nocturnal;
            _repository.Update(animal);
        }

        public void Sunset(int animalId)
        {
            var animal = GetById(animalId);
            if (animal == null) return;

            animal.IsAwake = animal.ActivityPattern != ActivityPattern.Diurnal;
            _repository.Update(animal);
        }

        public string FeedingTime(int animalId)
        {
            var animal = GetById(animalId);
            if (animal == null)
            {
                return "Animal not found";
            }

            if (animal.Prey.Any())
            {
                return $"{animal.Name} eats {string.Join(", ", animal.Prey.Select(p => p.Name))}";
            }

            return animal.DietaryClass switch
            {
                DietaryClass.Carnivore => $"{animal.Name} eats meat",
                DietaryClass.Herbivore => $"{animal.Name} eats plants",
                DietaryClass.Omnivore => $"{animal.Name} eats plants and meat",
                DietaryClass.Insectivore => $"{animal.Name} eats insects",
                DietaryClass.Piscivore => $"{animal.Name} eats fish",
                _ => $"{animal.Name} eats food"
            };
        }

        public IEnumerable<string> CheckConstraints(int animalId)
        {
            var animal = GetById(animalId);
            var result = new List<string>();

            if (animal == null)
            {
                result.Add("Animal not found!");
                return result;
            }

            if (animal.Enclosure == null)
            {
                result.Add("Animal has no enclosure assigned");
                return result;
            }

            if (animal.Enclosure.SecurityLevel < animal.SecurityRequirement)
            {
                result.Add("Enclosure security level is too low");
            }

            var requiredSpace = animal.SpaceRequirement;
            var availableSpace = animal.Enclosure.Size / animal.Enclosure.Animals.Count;

            if (availableSpace < requiredSpace)
            {
                result.Add("Not enough space in enclosure");
            }

            if (!result.Any())
            {
                result.Add("All constraints satisfied");
            }

            return result;
        }
    }
}
