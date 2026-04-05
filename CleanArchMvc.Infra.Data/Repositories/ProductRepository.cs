using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories;

public class ProductRepository(ApplicationDbContext _context) : IProductRepository
{
    public async Task<Product> CreateAsync(Product product, CancellationToken cancellationToken)
    {
        await _context.Products.AddAsync(product, cancellationToken);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.Products
            .Include(p => p.Category)  
            .FirstOrDefaultAsync(p => p.Id == id);
    }

   

    public async Task<Product?> GetProductCategoryAsync(int? id, CancellationToken cancellationToken)
    {
        // eager loading
        return await _context.Products.Include(c => c.Category)
            .SingleOrDefaultAsync(p => p.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<Product>> GetProductsAsync(CancellationToken cancellationToken)
    {
        var products = await _context.Products
            .Include(p => p.Category)  
            .ToListAsync(cancellationToken);
        return products;
    }

    public async Task<Product> RemoveAsync(Product product, CancellationToken cancellationToken)
    {
        _context.Products.Remove(product);
        await _context.SaveChangesAsync(cancellationToken);
        return product;
    }

    public async Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken)
    {
        _context.Update(product);
        await _context.SaveChangesAsync(cancellationToken);
        return product;
    }
}
