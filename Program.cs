using Microsoft.EntityFrameworkCore;
using SteamPayClone.Models;

var builder = WebApplication.CreateBuilder(args);

// Добавление контекста базы данных
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 29))));

// Добавление кэша и сессий
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

// Регистрация контроллеров с представлениями (важно!)
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles(); // Поддержка статических файлов
app.UseRouting();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
