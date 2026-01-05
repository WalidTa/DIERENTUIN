using ZooManagement.Core.Interfaces;
using ZooManagement.Core.Services.Enclosures;
using ZooManagement.Core.Services.Animals;

namespace ZooManagement.Core.Services.Zoo
{
    public class ZooService : IZooService
    {
        private readonly IAnimalService _animalService;
        private readonly IEnclosureService _enclosureService;
        private readonly IEnclosureRepository _enclosureRepository;
        private readonly IAnimalRepository _animalRepository;

        public ZooService(
            IAnimalService animalService,
            IEnclosureService enclosureService,
            IEnclosureRepository enclosureRepository,
            IAnimalRepository animalRepository)
        {
            _animalService = animalService;
            _enclosureService = enclosureService;
            _enclosureRepository = enclosureRepository;
            _animalRepository = animalRepository;
        }

        public IEnumerable<string> Sunrise()
        {
            var results = new List<string>();

            foreach (var enclosure in _enclosureRepository.GetAll())
            {
                results.AddRange(_enclosureService.Sunrise(enclosure.Id));
            }

            return results;
        }

        public IEnumerable<string> Sunset()
        {
            var results = new List<string>();

            foreach (var enclosure in _enclosureRepository.GetAll())
            {
                results.AddRange(_enclosureService.Sunset(enclosure.Id));
            }

            return results;
        }

        public IEnumerable<string> FeedingTime()
        {
            var results = new List<string>();

            foreach (var enclosure in _enclosureRepository.GetAll())
            {
                results.AddRange(_enclosureService.FeedingTime(enclosure.Id));
            }

            return results;
        }

        public IEnumerable<string> CheckConstraints()
        {
            var results = new List<string>();

            foreach (var enclosure in _enclosureRepository.GetAll())
            {
                results.AddRange(_enclosureService.CheckConstraints(enclosure.Id));
            }

            return results;
        }

        // public async Task<List<string>> AutoAssignAsync()
        // {
        //     var zoo = await _zooRepository.GetZooWithEnclosuresAsync();
        //     if (zoo == null)
        //         throw new InvalidOperationException("Zoo not found.");

        //     var unassignedAnimals = await _animalRepository.GetUnassignedAnimalsAsync();

        //     var results = new List<string>();

        //     foreach (var animal in unassignedAnimals)
        //     {
        //         var suitableEnclosure = zoo.Enclosures.FirstOrDefault(e =>
        //             e.Size >= e.Animals.Count * animal.SpaceRequirement &&
        //             e.SecurityLevel >= animal.SecurityRequirement);

        //         if (suitableEnclosure != null)
        //         {
        //             suitableEnclosure.Animals.Add(animal);
        //             animal.EnclosureId = suitableEnclosure.Id;

        //             results.Add($"{animal.Name} assigned to existing enclosure {suitableEnclosure.Name}.");
        //         }
        //         else
        //         {
        //             var newEnclosure = new Enclosure
        //             {
        //                 Name = $"Enclosure for {animal.Name}",
        //                 Size = animal.SpaceRequirement * 5,
        //                 SecurityLevel = animal.SecurityRequirement,
        //                 Animals = new List<Animal> { animal }
        //             };

        //             zoo.Enclosures.Add(newEnclosure);
        //             await _enclosureRepository.AddAsync(newEnclosure);

        //             results.Add($"{animal.Name} assigned to new enclosure {newEnclosure.Name}.");
        //         }
        //     }

        //     await _unitOfWork.SaveChangesAsync();
        //     return results;
        // }

    }
}
