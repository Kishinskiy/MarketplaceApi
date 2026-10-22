namespace Marketplace.Api.DTOs;

public record ProductResponseDto(
    Guid Id,
    string Name,
    string Description,
    decimal Price,
    DateTime CreatedAt
);
