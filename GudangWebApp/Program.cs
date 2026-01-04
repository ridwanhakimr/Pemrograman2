using GudangWebApp.Models; // Tambahkan using Models
using Microsoft.EntityFrameworkCore; // Tambahkan using EF Core

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Tambahkan konfigurasi Database SQLite
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=gudang.db"));

builder.Services.AddControllersWithViews()
    .AddViewOptions(options => {
        // Mengaktifkan validasi client-side (opsional sesuai halaman 9 modul)
        options.HtmlHelperOptions.ClientValidationEnabled = true;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();