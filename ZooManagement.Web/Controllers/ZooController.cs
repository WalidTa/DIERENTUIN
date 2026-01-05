using Microsoft.AspNetCore.Mvc;
using ZooManagement.Core.Services.Zoo;

namespace ZooManagement.Web.Controllers
{
    [ApiController]
    [Route("api/zoo")]
    public class ZooController : ControllerBase
    {
        private readonly IZooService _zooService;

        public ZooController(IZooService zooService)
        {
            _zooService = zooService;
        }

        [HttpPost("sunrise")]
        public IActionResult Sunrise()
            => Ok(_zooService.Sunrise());

        [HttpPost("sunset")]
        public IActionResult Sunset()
            => Ok(_zooService.Sunset());

        [HttpPost("feedingtime")]
        public IActionResult FeedingTime()
            => Ok(_zooService.FeedingTime());

        [HttpPost("checkconstraints")]
        public IActionResult CheckConstraints()
            => Ok(_zooService.CheckConstraints());

        [HttpPost("{id:int}/auto-assign")]
public async Task<IActionResult> AutoAssign(int id, bool completeExisting = true)
{
    var zoo = await _context.Zoos
        .Include(z => z.Enclosures)
        .ThenInclude(e => e.Animals)
        .FirstOrDefaultAsync(z => z.Id == id);

    if (zoo == null)
        return NotFound("Zoo not found.");

    var unassignedAnimals = await _context.Animals
        .Where(a => a.EnclosureId == null)
        .ToListAsync();

    var assignmentResults = new List<string>();

    foreach (var animal in unassignedAnimals)
    {
        var suitableEnclosure = zoo.Enclosures.FirstOrDefault(e =>
            e.Size >= e.Animals.Count * animal.SpaceRequirement &&
            (int)e.SecurityLevel >= (int)animal.SecurityRequirement);

        if (suitableEnclosure != null)
        {
            suitableEnclosure.Animals.Add(animal);
            animal.EnclosureId = suitableEnclosure.Id;

            assignmentResults.Add(
                $"{animal.Name} assigned to existing enclosure {suitableEnclosure.Name}.");
        }
        else
        {
            var newEnclosure = new Enclosure
            {
                Name = $"Enclosure for {animal.Name}",
                Size = animal.SpaceRequirement * 5,
                SecurityLevel = animal.SecurityRequirement,
                Animals = new List<Animal> { animal }
            };

            zoo.Enclosures.Add(newEnclosure);
            _context.Enclosures.Add(newEnclosure);

            assignmentResults.Add(
                $"{animal.Name} assigned to new enclosure {newEnclosure.Name}.");
        }
    }

    await _context.SaveChangesAsync();

    return Ok(assignmentResults);
}


    }
}
