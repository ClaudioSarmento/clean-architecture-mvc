using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories;

public class ProductRepository : IProductRepository
{
    private ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context; 
    }

    public async Task<Product> CreateAsync(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product?> GetByIdAsync(int? id)
    {
       var product = await _context.Products.FindAsync(id);
       return product;
    }

    public async Task<Product?> GetProductCategoryAsync(int? id)
    {
        // eager loading
        return await _context.Products.Include(c => c.Category)
            .SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IReadOnlyList<Product>> GetProductsAsync()
    {
        var products = await _context.Products
            .AsNoTracking()
            .ToListAsync();
        return products;
    }

    public async Task<Product> RemoveAsync(Product product)
    {
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product> UpdateAsync(Product product)
    {
        _context.Update(product);
        await _context.SaveChangesAsync();
        return product;
    }
}
