using Microsoft.EntityFrameworkCore;
using Marketplace.Api.Data;
using Marketplace.Api.Models;
using Marketplace.Api.DTOs;

namespace Marketplace.Api.Services;

// Ключевое слово ':' означает наследование или реализацию интерфейса
public class ProductService : IProductService
{
    private readonly AppDbContext _context;

    // Внедряем базу данных теперь сюда, а не в контроллер
    public ProductService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ProductResponseDto>> GetAllProductsAsync()
    {
        return await _context.Products
            .Select(p => new ProductResponseDto(p.Id, p.Name, p.Description, p.Price, p.CreatedAt))
            .ToListAsync();
    }

    public async Task<ProductResponseDto?> GetProductByIdAsync(Guid id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null) return null;

        return new ProductResponseDto(product.Id, product.Name, product.Description, product.Price, product.CreatedAt);
    }

    public async Task<ProductResponseDto> CreateProductAsync(ProductCreateDto dto)
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            CreatedAt = DateTime.UtcNow
        };

        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return new ProductResponseDto(product.Id, product.Name, product.Description, product.Price, product.CreatedAt);
    }

    public async Task<bool> UpdateProductAsync(Guid id, ProductCreateDto dto)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null) return false;

        product.Name = dto.Name;
        product.Description = dto.Description;
        product.Price = dto.Price;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteProductAsync(Guid id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null) return false;

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return true;
    }
}
