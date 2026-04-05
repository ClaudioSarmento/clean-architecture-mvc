using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace CleanArchMvc.WebUI.Controllers;

public class ProductsController : Controller
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;

    public ProductsController(IProductService productService, ICategoryService categoryService)
    {
        _productService = productService;
        _categoryService = categoryService;
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
        var result = await _productService.GetProductByIdAsync(id, cancellationToken);
        var categories = await _categoryService.GetCategoriesAsync(cancellationToken);
        ViewBag.Categories = categories;
        return View(result);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ProductDTO product, CancellationToken cancellationToken)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _productService.UpdateAsync(product, cancellationToken);
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction(nameof(Index));
        }
        var categories = await _categoryService.GetCategoriesAsync(cancellationToken);
        ViewBag.Categories = categories;
        return View(product);
    }

    [HttpGet]
    public async Task<IActionResult> Create(CancellationToken cancellationToken)
    {
        var categories = await _categoryService.GetCategoriesAsync(cancellationToken);
        ViewBag.Categories = categories;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProductDTO product, CancellationToken cancellationToken)
    {
        if (ModelState.IsValid)
        {
            await _productService.AddAsync(product, cancellationToken);
            return RedirectToAction(nameof(Index));
        }
        var categories = await _categoryService.GetCategoriesAsync(cancellationToken);
        ViewBag.Categories = categories;
        return View(product);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id, CancellationToken cancellationToken)
    {
        await _productService.DeleteAsync(id, cancellationToken);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
    {
        var result = await _productService.GetProductByIdAsync(id, cancellationToken);
        return View(result);
    }
}
