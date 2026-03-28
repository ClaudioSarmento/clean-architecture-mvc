using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Application.Products.Queries;
using CleanArchMvc.Application.Services.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Services;

public class ProductService : IProductService
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public ProductService(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<ProductDTO> GetProductByIdAsync(int id, CancellationToken cancellationToken)
    {
        var productQuery = new GetProductByIdQuery(id);
        var result = await _mediator.Send(productQuery, cancellationToken);
        var productDTO = _mapper.Map<ProductDTO>(result);
        return productDTO;
    }

    public async Task<IReadOnlyList<ProductDTO>> GetProductsAsync(CancellationToken cancellationToken)
    {
        var productsQuery = new GetProductsQuery();
        var result = await _mediator.Send(productsQuery, cancellationToken);
        var productsDTO = _mapper.Map<IReadOnlyList<ProductDTO>>(result);
        return productsDTO;
    }

    public async Task AddAsync(ProductDTO product, CancellationToken cancellationToken)
    {
        var productCreateCommand = _mapper.Map<ProductCreateCommand>(product);
        await _mediator.Send(productCreateCommand, cancellationToken);
    }

    public async Task UpdateAsync(ProductDTO product, CancellationToken cancellationToken)
    {
        var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(product);
        await _mediator.Send(productUpdateCommand, cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var productRemoveCommand = new ProductRemoveCommand(id);
        await _mediator.Send(productRemoveCommand, cancellationToken);
    }
}
