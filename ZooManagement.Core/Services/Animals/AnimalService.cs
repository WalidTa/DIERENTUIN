using ZooManagement.Core.Entities;
using ZooManagement.Core.Enums;

namespace ZooManagement.Core.Services.Animals
{
    public class AnimalService : IAnimalService
    {
        private readonly IList<Animal> _animals;

        public AnimalService(IList<Animal> animals)
        {
            _animals = animals;
        }

        // CRUD
        public IEnumerable<Animal> GetAll()
        {
            return _animals;
        }

        public Animal? GetById(int id)
        {
            return _animals.FirstOrDefault(a => a.Id == id);
        }

        public Animal Create(Animal animal)
        {
            _animals.Add(animal);
            return animal;
        }

        public Animal Update(Animal animal)
        {
            var existing = GetById(animal.Id);
            if (existing == null)
            {
                throw new InvalidOperationException("Animal not found");
            }

            existing.Name = animal.Name;
            existing.Species = animal.Species;
            existing.Size = animal.Size;
            existing.DietaryClass = animal.DietaryClass;
            existing.ActivityPattern = animal.ActivityPattern;
            existing.SpaceRequirement = animal.SpaceRequirement;
            existing.SecurityRequirement = animal.SecurityRequirement;

            return existing;
        }

        public void Delete(int id)
        {
            var animal = GetById(id);
            if (animal != null)
            {
                _animals.Remove(animal);
            }
        }

        // Actions
        public void Sunrise(int animalId)
        {
            var animal = GetById(animalId);
            if (animal == null) return;

            if (animal.ActivityPattern == ActivityPattern.Nocturnal)
            {
                animal.IsAwake = false;
            }
            else
            {
                animal.IsAwake = true;
            }
        }

        public void Sunset(int animalId)
        {
            var animal = GetById(animalId);
            if (animal == null) return;

            if (animal.ActivityPattern == ActivityPattern.Diurnal)
            {
                animal.IsAwake = false;
            }
            else
            {
                animal.IsAwake = true;
            }
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
