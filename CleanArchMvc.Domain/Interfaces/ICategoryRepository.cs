using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces;

public interface ICategoryRepository
{
    Task<IReadOnlyList<Category>> GetCategoriesAsync(CancellationToken cancellationToken);
    Task<Category?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<Category> CreateAsync(Category category, CancellationToken cancellationToken);
    Task<Category> UpdateAsync(Category category, CancellationToken cancellationToken);
    Task<Category> RemoveAsync(Category category, CancellationToken cancellationToken);
}
