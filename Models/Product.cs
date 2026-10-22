namespace Marketplace.Api.Models;

public class Product
{
    // В C# принято использовать тип Guid или int для ID. 
    // Guid исключает коллизии и безопаснее для распределенных систем.
    public Guid Id { get; set; }

    // string - ссылочный тип. string.Empty - аналог пустой строки "" во избежание null-ошибок.
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    // Для денег в C# ВСЕГДА используется тип decimal (высокая точность, аналог Decimal в Python)
    public decimal Price { get; set; }

    // Дата создания товара. DateTime.UtcNow - стандарт для бэкенда.
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
