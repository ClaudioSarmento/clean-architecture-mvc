using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Services.Interfaces;
using CleanArchMvc.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
        {
            var categories = await _categoryService.GetCategoriesAsync(cancellationToken);
            if (categories == null)
                return NotFound("Categories not found");
            return Ok(categories);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id, cancellationToken);
            if (category == null)
                return NotFound("Category not found");
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CategoryDTO category, CancellationToken cancellationToken)
        {
            await _categoryService.AddAsync(category, cancellationToken);
            return new CreatedAtActionResult(nameof(GetByIdAsync), "Categories", new { id = category.Id }, category);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] CategoryDTO category, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);
            if (id != category.Id)
                return BadRequest("Route id does not match category id");
            await _categoryService.UpdateAsync(category, cancellationToken);
            return Ok(category);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id, cancellationToken);
            if (category == null)
                return NotFound("Category not found");
            await _categoryService.RemoveAsync(id, cancellationToken);
            return Ok(category);
        }
    }
}
