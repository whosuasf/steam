namespace SteamPayClone.Models;

public class CartItem
{
    public int Id { get; set; } // Первичный ключ
    public int ProductId { get; set; } // Связь с товаром
    public Product Product { get; set; } = null!; // Навигационное свойство
    public string SessionId { get; set; } = string.Empty; // Идентификатор сессии
    public int Quantity { get; set; } // Количество
}
