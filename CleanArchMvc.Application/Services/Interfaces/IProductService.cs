using CleanArchMvc.Application.DTOs;

namespace CleanArchMvc.Application.Services.Interfaces;

public interface IProductService
{
    Task<IReadOnlyList<ProductDTO>> GetProductsAsync(CancellationToken cancellationToken);
    Task<ProductDTO> GetProductByIdAsync(int id, CancellationToken cancellationToken);

    Task AddAsync(ProductDTO product, CancellationToken cancellationToken);
    Task UpdateAsync(ProductDTO product, CancellationToken cancellationToken);
    Task DeleteAsync(int id, CancellationToken cancellationToken);

}
