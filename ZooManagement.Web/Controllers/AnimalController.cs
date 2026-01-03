using Microsoft.AspNetCore.Mvc;
using ZooManagement.Core.Entities;
using ZooManagement.Core.Services.Animals;

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

        [HttpGet]
        public IActionResult GetAll()
        {
            var animals = _animalService.GetAll()
        .Select(a => new AnimalDto 
        { 
            Id = a.Id, 
            Name = a.Name, 
            Species = a.Species, 
            EnclosureName = a.Enclosure?.Name 
        });
            return Ok(animals);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var animal = _animalService.GetById(id);
            if (animal == null)
            {
                return NotFound();
            }
            return Ok(animal);
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