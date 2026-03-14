using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces;

public interface IProductRepository
{
    Task<IReadOnlyList<Product>> GetProductsAsync();
    Task<Product?> GetByIdAsync(int? id);
    Task<Product?> GetProductCategoryAsync(int? categoryId);
    Task<Product> CreateAsync(Product product);
    Task<Product> UpdateAsync(Product product);
    Task<Product> RemoveAsync(Product product);
}
