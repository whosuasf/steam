namespace SteamPayClone.Models;

public class Product
{
    public int Id { get; set; } // Уникальный идентификатор товара
    public string Name { get; set; } = string.Empty; // Название товара
    public string Description { get; set; } = string.Empty; // Описание товара
    public decimal Price { get; set; } // Цена товара
}
