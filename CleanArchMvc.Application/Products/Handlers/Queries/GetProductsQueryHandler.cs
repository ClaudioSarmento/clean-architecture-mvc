using CleanArchMvc.Application.Products.Queries;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Products.Handlers.Queries;

public class GetProductsQueryHandler(IProductRepository _productRepository) : IRequestHandler<GetProductsQuery, IReadOnlyList<Product>>
{
    public async Task<IReadOnlyList<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetProductsAsync(cancellationToken);
        return products;
    }
}
