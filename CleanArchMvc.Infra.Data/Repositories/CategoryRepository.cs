using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Domain.Validation;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private ApplicationDbContext _categoryContext;

    public  CategoryRepository(ApplicationDbContext context) {  _categoryContext = context; }

    public async Task<Category> CreateAsync(Category category)
    {
        _categoryContext.Categories.Add(category);
        await _categoryContext.SaveChangesAsync();
        return category;
    }

    public async Task<Category?> GetByIdAsync(int? id)
    {
        var category = await _categoryContext.Categories.FindAsync(id);
        return category;
    }

    public async Task<IReadOnlyList<Category>> GetCategoriesAsync()
    {
        var categories = await _categoryContext.Categories
            .AsNoTracking()
            .ToListAsync();
        return categories;
    }

    public async Task<Category> RemoveAsync(Category category)
    {
        _categoryContext.Remove(category);
        await _categoryContext.SaveChangesAsync();
        return category;
    }

    public async Task<Category> UpdateAsync(Category category)
    {
        _categoryContext.Update(category);
        await _categoryContext.SaveChangesAsync();
        return category;
    }
}
