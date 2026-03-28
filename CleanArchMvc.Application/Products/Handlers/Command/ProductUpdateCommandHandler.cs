using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Products.Handlers.Command;

public class ProductUpdateCommandHandler(IProductRepository _productRepository) : IRequestHandler<ProductUpdateCommand, Product>
{
    public async Task<Product> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id, cancellationToken);

        if (product == null)
        {
            throw new ApplicationException($"Product with id {request.Id} not found.");
        }
        else
        {
            product.Update(request.Name, request.Description, request.Price, request.Stock, request.Image, request.CategoryId);
            return await _productRepository.UpdateAsync(product, cancellationToken);
        }

    }
}
