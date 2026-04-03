using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace CleanArchMvc.WebUI.Controllers;

public class ProductsController : Controller
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var result = await _productService.GetProductsAsync(cancellationToken);
        return View(result);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken)
    {
        var result = await _productService.GetProductByIdAsync(id,cancellationToken);
        return View(result);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ProductDTO productDTO, CancellationToken cancellationToken)
    {
        await _productService.UpdateAsync(productDTO, cancellationToken);
        return RedirectToAction(nameof(Index));
    }
}
