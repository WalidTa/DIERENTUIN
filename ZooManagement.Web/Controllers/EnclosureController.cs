using Microsoft.AspNetCore.Mvc;
using ZooManagement.Core.Entities;
using ZooManagement.Core.Services.Enclosures;

namespace ZooManagement.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnclosureController : ControllerBase
    {
        private readonly IEnclosureService _enclosureService;

        public EnclosureController(IEnclosureService enclosureService)
        {
            _enclosureService = enclosureService;
        }

        // GET: api/Enclosure
        [HttpGet]
        public IActionResult GetAll()
        {
            var enclosures = _enclosureService.GetAll()
                .Select(e => new
                {
                    e.Id,
                    e.Name,
                    e.Climate,
                    e.HabitatType,
                    e.SecurityLevel,
                    e.Size,
                    Animals = e.Animals?.Select(a => new
                    {
                        a.Id,
                        a.Name,
                        a.Species
                    })
                });

            return Ok(enclosures);
        }

        // GET: api/Enclosure/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var enclosure = _enclosureService.GetById(id);
            if (enclosure == null) return NotFound();

            var result = new
            {
                enclosure.Id,
                enclosure.Name,
                enclosure.Climate,
                enclosure.HabitatType,
                enclosure.SecurityLevel,
                enclosure.Size,
                Animals = enclosure.Animals?.Select(a => new
                {
                    a.Id,
                    a.Name,
                    a.Species
                })
            };

            return Ok(result);
        }

        // POST: api/Enclosure
        [HttpPost]
        public IActionResult Create([FromBody] Enclosure enclosure)
        {
            var created = _enclosureService.Create(enclosure);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT: api/Enclosure/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Enclosure enclosure)
        {
            if (id != enclosure.Id) return BadRequest();

            try
            {
                var updated = _enclosureService.Update(enclosure);
                return Ok(updated);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        // DELETE: api/Enclosure/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _enclosureService.Delete(id);
            return NoContent();
        }

        [HttpPut("{id}/sunrise")]
        public IActionResult Sunrise(int id)
        {
            var activity = _enclosureService.Sunrise(id);
            return Ok(activity);
        }

        [HttpPut("{id}/sunset")]
        public IActionResult Sunset(int id)
        {
            var activity = _enclosureService.Sunset(id);
            return Ok(activity);
        }

        [HttpGet("{id}/feedingtime")]
        public IActionResult FeedingTime(int id)
        {
            var feedingTimes = _enclosureService.FeedingTime(id);
            return Ok(feedingTimes);
        }

        [HttpGet("{id}/checkconstraints")]
        public IActionResult CheckConstraints(int id)
        {
            var constraints = _enclosureService.CheckConstraints(id);
            return Ok(constraints);
        }
    }
}
