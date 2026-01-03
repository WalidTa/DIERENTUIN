using Microsoft.AspNetCore.Mvc;
using ZooManagement.Core.Services.Animals;
using ZooManagement.Core.Entities;

namespace ZooManagement.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalService _animalService;

        public AnimalsController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        // GET ALL 
        [HttpGet]
        public IActionResult GetAll()
        {
           
            var animals = _animalService.GetAll()
                .Select(a => new
                {
                    a.Id,
                    a.Name,
                    a.Species,
                    a.Size,
                    a.DietaryClass,
                    a.ActivityPattern,
                    a.SpaceRequirement,
                    a.SecurityRequirement,
                    a.CategoryId,
                    CategoryName = a.Category?.Name,
                    a.EnclosureId,
                    EnclosureName = a.Enclosure?.Name,
                    EnclosureSize = a.Enclosure?.Size,
                    EnclosureSecurity = a.Enclosure?.SecurityLevel
                });

            return Ok(animals);
        }

        // --- GET BY ID ---
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var animal = _animalService.GetById(id);
            if (animal == null) return NotFound();

            var result = new
            {
                animal.Id,
                animal.Name,
                animal.Species,
                animal.Size,
                animal.DietaryClass,
                animal.ActivityPattern,
                animal.SpaceRequirement,
                animal.SecurityRequirement,
                animal.CategoryId,
                CategoryName = animal.Category?.Name,
                animal.EnclosureId,
                EnclosureName = animal.Enclosure?.Name,
                EnclosureSize = animal.Enclosure?.Size,
                EnclosureSecurity = animal.Enclosure?.SecurityLevel
            };

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Animal animal)
        {
            var createdAnimal = _animalService.Create(animal);
            return CreatedAtAction(nameof(GetById), new { id = createdAnimal.Id }, createdAnimal);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Animal animal)
        {
            if (id != animal.Id)
            {
                return BadRequest();
            }

            try
            {
                var updatedAnimal = _animalService.Update(animal);
                return Ok(updatedAnimal);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _animalService.Delete(id);
            return NoContent();
        }

        [HttpPost("{id}/sunrise")]
        public IActionResult Sunrise(int id)
        {
            _animalService.Sunrise(id);
            return NoContent();
        }

        [HttpPost("{id}/sunset")]
        public IActionResult Sunset(int id)
        {
            _animalService.Sunset(id);
            return NoContent();
        }

        [HttpGet("{id}/feedingtime")]
        public IActionResult FeedingTime(int id)
        {
            var feedingTime = _animalService.FeedingTime(id);
            return Ok(feedingTime);
        }

        [HttpGet("{id}/checkconstraints")]
        public IActionResult CheckConstraints(int id)
        {
            var constraints = _animalService.CheckConstraints(id);
            return Ok(constraints);
        }
    }
}