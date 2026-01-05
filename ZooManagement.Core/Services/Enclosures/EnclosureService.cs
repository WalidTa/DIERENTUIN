using ZooManagement.Core.Entities;
using ZooManagement.Core.Interfaces;
using ZooManagement.Core.Enums;

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

        public IEnumerable<string> Sunrise(int enclosureId)
        {
            var enclosure = GetById(enclosureId);
            if (enclosure == null)
                throw new InvalidOperationException("Enclosure not found");

            var results = new List<string>();

                foreach (var animal in enclosure.Animals)
                {
                    switch (animal.ActivityPattern)
                    {
                        case ActivityPattern.Diurnal:
                            animal.IsAwake = true;
                            results.Add($"{animal.Name} wakes up in: {enclosure.Name}.");
                            break;

                        case ActivityPattern.Nocturnal:
                            animal.IsAwake = false;
                            results.Add($"{animal.Name} goes to sleep in: {enclosure.Name}.");
                            break;

                        default:
                            animal.IsAwake = true;
                            results.Add($"{animal.Name} remains active in: {enclosure.Name}.");
                            break;
                    }
                }

                _repository.Update(enclosure);
                // todo swagger geeft geen output
                return results;
        }

        public IEnumerable<string> Sunset(int enclosureId)
        {
            var enclosure = GetById(enclosureId);
            if (enclosure == null)
                throw new InvalidOperationException("Enclosure not found");

           var results = new List<string>();

                foreach (var animal in enclosure.Animals)
                {
                    switch (animal.ActivityPattern)
                    {
                        case ActivityPattern.Nocturnal:
                            animal.IsAwake = true;
                            results.Add($"{animal.Name} wakes up in: {enclosure.Name}.");
                            break;

                        case ActivityPattern.Diurnal:
                            animal.IsAwake = false;
                            results.Add($"{animal.Name} goes to sleep in: {enclosure.Name}.");
                            break;

                        default:
                            animal.IsAwake = true;
                            results.Add($"{animal.Name} remains active in: {enclosure.Name}.");
                            break;
                    }
                }

                _repository.Update(enclosure);
                //to do swagger geeft geen output
                return results;
        }

        public IEnumerable<string> FeedingTime(int enclosureId)
        {
            var enclosure = GetById(enclosureId);
            if (enclosure == null)
                throw new InvalidOperationException("Enclosure not found");

            var results = new List<string>();

            foreach (var animal in enclosure.Animals)
            {
                if (animal.Prey.Any())
                {
                    results.Add(
                        $"{animal.Name} eats its prey {string.Join(", ", animal.Prey.Select(p => p.Name))} in: {enclosure.Name}."
                    );
                }
                else
                {
                    results.Add(
                        $"{animal.Name} is fed its diet: ({animal.DietaryClass}) in: {enclosure.Name}."
                    );
                }
            }

            return results;
        }


        public IEnumerable<string> CheckConstraints(int enclosureId)
        {
            var enclosure = GetById(enclosureId);
            if (enclosure == null)
                throw new InvalidOperationException("Enclosure not found");

            var results = new List<string>();

            foreach (var animal in enclosure.Animals)
            {
                var statusParts = new List<string>();
                double availableSpace = enclosure.Size / enclosure.Animals.Count;

                if (availableSpace < animal.SpaceRequirement)
                    statusParts.Add("insufficient space");
                else
                    statusParts.Add("sufficient space");

                if (enclosure.SecurityLevel < animal.SecurityRequirement)
                    statusParts.Add("security requirements not met");
                else
                    statusParts.Add("security requirements met");

                results.Add(
                    $"{animal.Name} in {enclosure.Name}: {string.Join(", ", statusParts)}."
                );
            }

            return results;
        }

    }
}
