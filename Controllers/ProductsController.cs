using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class ProductsController : Controller
{
    private readonly ApplicationDbContext _context;

    public ProductsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var products = _context.Products.ToList();
        return View(products);
    }

    public IActionResult Details(int id)
    {
        var product = _context.Products.Find(id);
        if (product == null) return NotFound();
        return View(product);
    }
}
