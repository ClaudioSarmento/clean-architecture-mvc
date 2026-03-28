using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories;

public class CategoryRepository(ApplicationDbContext _categoryContext) : ICategoryRepository
{
    public async Task<Category> CreateAsync(Category category, CancellationToken cancellationToken)
    {
        _categoryContext.Categories.Add(category);
        await _categoryContext.SaveChangesAsync();
        return category;
    }

    public async Task<Category?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var category = await _categoryContext.Categories.FindAsync(id);
        return category;
    }

    public async Task<IReadOnlyList<Category>> GetCategoriesAsync(CancellationToken cancellationToken)
    {
        var categories = await _categoryContext.Categories
            .AsNoTracking()
            .ToListAsync();
        return categories;
    }

    public async Task<Category> RemoveAsync(Category category, CancellationToken cancellationToken)
    {
        _categoryContext.Remove(category);
        await _categoryContext.SaveChangesAsync();
        return category;
    }

    public async Task<Category> UpdateAsync(Category category, CancellationToken cancellationToken)
    {
         _categoryContext.Update(category);
        await _categoryContext.SaveChangesAsync();
        return category;
    }
}
