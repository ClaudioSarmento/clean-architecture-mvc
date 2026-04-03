using CleanArchMvc.Application.DTOs;

namespace CleanArchMvc.Application.Services.Interfaces;

public interface ICategoryService
{
    Task<IReadOnlyList<CategoryDTO>> GetCategoriesAsync(CancellationToken cancellationToken);
    Task<CategoryDTO> GetCategoryByIdAsync(int id, CancellationToken cancellationToken);
    Task AddAsync(CategoryDTO category, CancellationToken cancellationToken);
    Task UpdateAsync(CategoryDTO category, CancellationToken cancellationToken);
    Task RemoveAsync(int id, CancellationToken cancellationToken);
}
