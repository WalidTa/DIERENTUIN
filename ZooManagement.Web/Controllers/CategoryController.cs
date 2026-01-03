using Microsoft.AspNetCore.Mvc;
using ZooManagement.Core.Entities;
using ZooManagement.Core.Services.Categories;

namespace ZooManagement.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/Categories
        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = _categoryService.GetAll()
                .Select(c => new
                {
                    c.Id,
                    c.Name,
                    Animals = c.Animals?.Select(a => new 
                    {
                        a.Id,
                        a.Name,
                        a.Species
                    })
                });

            return Ok(categories);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var category = _categoryService.GetById(id);
            if (category == null) return NotFound();

            var result = new
            {
                category.Id,
                category.Name,
                Animals = category.Animals?.Select(a => new
                {
                    a.Id,
                    a.Name,
                    a.Species
                })
            };

            return Ok(result);
        }

        // POST: api/Categories
        [HttpPost]
        public IActionResult Create([FromBody] Category category)
        {
            var createdCategory = _categoryService.Create(category);
            return CreatedAtAction(nameof(GetById), new { id = createdCategory.Id }, createdCategory);
        }

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Category category)
        {
            if (id != category.Id) return BadRequest();

            try
            {
                var updatedCategory = _categoryService.Update(category);
                return Ok(updatedCategory);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _categoryService.Delete(id);
            return NoContent();
        }
    }
}
