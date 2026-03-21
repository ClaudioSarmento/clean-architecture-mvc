using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Controllers;

public class CategoriesController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var result = await _categoryService.GetCategoriesAsync();
        return View(result);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var result = await _categoryService.GetCategoryByIdAsync(id);
        return View(result);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(CategoryDTO categoryDTO)
    {
        await _categoryService.UpdateAsync(categoryDTO);
        return RedirectToAction(nameof(Index));
    }
}
