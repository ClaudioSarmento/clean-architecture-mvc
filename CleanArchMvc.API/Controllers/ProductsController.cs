using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
        {
            var products = await _productService.GetProductsAsync(cancellationToken);
            if (products == null)
                return NotFound("Products not found");
            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var product = await _productService.GetProductByIdAsync(id, cancellationToken);
            if (product == null)
                return NotFound("Product not found");
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ProductDTO product, CancellationToken cancellationToken)
        {
            await _productService.AddAsync(product, cancellationToken);
           return new CreatedAtActionResult(nameof(GetByIdAsync), "Products", new { id = product.Id }, product);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] ProductDTO product, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);
            if (id != product.Id)
                return BadRequest("Route id does not match product id");
            if (id != product.Id)
                return BadRequest("Route id does not match product id");            await _productService.UpdateAsync(product, cancellationToken);
            return Ok(product);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var product = await _productService.GetProductByIdAsync(id, cancellationToken);
            if (product == null)
                return NotFound("Product not found");
            await _productService.DeleteAsync(id, cancellationToken);
            return Ok(product);
        }
    }
}
