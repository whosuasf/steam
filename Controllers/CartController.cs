using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class CartController : Controller
{
    private readonly ApplicationDbContext _context;

    public CartController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Получаем идентификатор текущей сессии
    private string GetSessionId()
{
    var sessionId = HttpContext.Session.GetString("SessionId");
    if (string.IsNullOrEmpty(sessionId))
    {
        sessionId = Guid.NewGuid().ToString();
        HttpContext.Session.SetString("SessionId", sessionId);
    }
    return sessionId;
}


    // Отображение корзины
    public IActionResult Index()
    {
        var sessionId = GetSessionId();
        var cartItems = _context.CartItems
            .Where(c => c.SessionId == sessionId)
            .ToList();
        return View(cartItems);
    }

    // Добавление товара в корзину
    [HttpPost]
    public IActionResult AddToCart(int productId)
    {
        var product = _context.Products.Find(productId);
        if (product == null) return NotFound();

        var sessionId = GetSessionId();
        var cartItem = _context.CartItems
            .FirstOrDefault(c => c.ProductId == productId && c.SessionId == sessionId);

        if (cartItem == null)
        {
            cartItem = new CartItem
            {
                ProductId = productId,
                Product = product,
                SessionId = sessionId,
                Quantity = 1
            };
            _context.CartItems.Add(cartItem);
        }
        else
        {
            cartItem.Quantity++;
        }

        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    // Удаление товара из корзины
    public IActionResult RemoveFromCart(int id)
    {
        var cartItem = _context.CartItems.Find(id);
        if (cartItem != null)
        {
            _context.CartItems.Remove(cartItem);
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }
}
