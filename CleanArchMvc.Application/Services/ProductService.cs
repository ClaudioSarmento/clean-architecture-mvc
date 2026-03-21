using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Services.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Services;

public class ProductService : IProductService
{
    private IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ProductDTO> GetProductByIdAsync(int id)
    {
        var productEntity = await _productRepository.GetByIdAsync(id);
        var productDTO = _mapper.Map<ProductDTO>(productEntity);
        return productDTO;
    }

    public async Task<IReadOnlyList<ProductDTO>> GetProductsAsync()
    {
        var productsEntity = await _productRepository.GetProductsAsync();
        var productsDTO = _mapper.Map<IReadOnlyList<ProductDTO>>(productsEntity);
        return productsDTO;
    }

    public async Task AddAsync(ProductDTO product)
    {
        var productEntity = _mapper.Map<Product>(product);
        await _productRepository.CreateAsync(productEntity);
    }

    public async Task UpdateAsync(ProductDTO product)
    {
        var productEntity = _mapper.Map<Product>(product);
        await _productRepository.UpdateAsync(productEntity);
    }

    public async Task DeleteAsync(int id)
    {
        var productEntity = await _productRepository.GetByIdAsync(id);
        await _productRepository.RemoveAsync(productEntity!);
    }
}
