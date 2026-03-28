using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Products.Handlers.Command;

public class ProductRemoveCommandHandler(IProductRepository _productRepository) : IRequestHandler<ProductRemoveCommand, Product>
{
    public async Task<Product> Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id, cancellationToken);

        return product == null ? throw new ApplicationException("Product not found.") 
            : await _productRepository.RemoveAsync(product, cancellationToken);
    }
}
