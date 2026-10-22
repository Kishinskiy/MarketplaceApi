using Microsoft.AspNetCore.Mvc;
using Marketplace.Api.DTOs;
using Marketplace.Api.Services;

namespace Marketplace.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    // Внедряем интерфейс сервиса
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductResponseDto>>> GetProducts()
    {
        var products = await _productService.GetAllProductsAsync();
        return Ok(products);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ProductResponseDto>> GetProduct(Guid id)
    {
        var product = await _productService.GetProductByIdAsync(id);
        if (product == null)
        {
            return NotFound(new { message = $"Товар с ID {id} не найден." });
        }
        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<ProductResponseDto>> CreateProduct(ProductCreateDto dto)
    {
        var response = await _productService.CreateProductAsync(dto);
        return CreatedAtAction(nameof(GetProducts), new { id = response.Id }, response);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateProduct(Guid id, ProductCreateDto dto)
    {
        var success = await _productService.UpdateProductAsync(id, dto);
        if (!success)
        {
            return NotFound(new { message = $"Товар с ID {id} не найден." });
        }
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        var success = await _productService.DeleteProductAsync(id);
        if (!success)
        {
            return NotFound(new { message = $"Товар с ID {id} не найден." });
        }
        return NoContent();
    }
}
