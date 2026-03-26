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
    public async Task<IActionResult> Index()
    {
        var result = await _productService.GetProductsAsync();
        return View(result);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var result = await _productService.GetProductByIdAsync(id);
        return View(result);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ProductDTO productDTO)
    {
        await _productService.UpdateAsync(productDTO);
        return RedirectToAction(nameof(Index));
    }
}
