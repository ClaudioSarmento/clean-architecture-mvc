using CleanArchMvc.Application.DTOs;

namespace CleanArchMvc.Application.Services.Interfaces;

public interface ICategoryService
{
    Task<IReadOnlyList<CategoryDTO>> GetCategoriesAsync();
    Task<CategoryDTO> GetCategoryByIdAsync(int id);
    Task AddAsync(CategoryDTO category);
    Task UpdateAsync(CategoryDTO category);
    Task RemoveAsync(int id);
}
