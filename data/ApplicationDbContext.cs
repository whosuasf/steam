using Microsoft.EntityFrameworkCore;
using SteamPayClone.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<CartItem> CartItems { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
}

// Модель товара
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
}

// Модель элемента корзины
public class CartItem
{
    public int Id { get; set; } // Первичный ключ
    public int ProductId { get; set; } // ID связанного продукта
    public Product Product { get; set; } = null!; // Связанный объект Product
    public string SessionId { get; set; } = string.Empty; // ID сессии
    public int Quantity { get; set; } // Количество
}


public class Order
{
    public int Id { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string CustomerEmail { get; set; } = string.Empty;
    public decimal TotalPrice { get; set; }
}
