using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces;

public interface IProductRepository
{
    Task<IReadOnlyList<Product>> GetProductsAsync(CancellationToken cancellationToken);
    Task<Product?> GetByIdAsync(int? id, CancellationToken cancellationToken);
    Task<Product?> GetProductCategoryAsync(int? categoryId, CancellationToken cancellationToken);
    Task<Product> CreateAsync(Product product, CancellationToken cancellationToken);
    Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken);
    Task<Product> RemoveAsync(Product product, CancellationToken cancellationToken);
}
