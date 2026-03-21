using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Services.Interfaces;

namespace CleanArchMvc.Application.Services;

public class ProductService : IProductService
{
    public Task<ProductDTO> AddAsync(ProductDTO product)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ProductDTO> GetProductByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<ProductDTO>> GetProductsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ProductDTO> UpdateAsync(ProductDTO product)
    {
        throw new NotImplementedException();
    }
}
