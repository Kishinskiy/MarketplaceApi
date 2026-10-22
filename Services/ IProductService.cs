using Marketplace.Api.DTOs;

namespace Marketplace.Api.Services;

public interface IProductService
{
    Task<IEnumerable<ProductResponseDto>> GetAllProductsAsync();
    Task<ProductResponseDto?> GetProductByIdAsync(Guid id);
    Task<ProductResponseDto> CreateProductAsync(ProductCreateDto dto);
    Task<bool> UpdateProductAsync(Guid id, ProductCreateDto dto);
    Task<bool> DeleteProductAsync(Guid id);
}
