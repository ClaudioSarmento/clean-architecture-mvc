using CleanArchMvc.Application.DTOs;

namespace CleanArchMvc.Application.Services.Interfaces;

public interface IProductService
{
    Task<IReadOnlyList<ProductDTO>> GetProductsAsync();
    Task<ProductDTO> GetProductByIdAsync(int id);

    Task<ProductDTO> AddAsync(ProductDTO product);
    Task<ProductDTO> UpdateAsync(ProductDTO product);
    Task DeleteAsync(int id);

}
