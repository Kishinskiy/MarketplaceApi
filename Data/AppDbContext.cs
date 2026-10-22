using Microsoft.EntityFrameworkCore;
using Marketplace.Api.Models;

namespace Marketplace.Api.Data;

// Наследуемся от базового класса EF Core
public class AppDbContext : DbContext
{
    // Конструктор принимает настройки (например, строку подключения) 
    // и передает их в базовый класс DbContext
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // DbSet - это представление таблицы в коде. 
    // EF Core автоматически создаст таблицу с именем "Products" на основе класса Product
    public DbSet<Product> Products { get; set; }
}
