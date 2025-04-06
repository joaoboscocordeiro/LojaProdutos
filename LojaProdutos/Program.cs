using LojaProdutos.Data;
<<<<<<< HEAD
using LojaProdutos.Services.Categoria;
=======
>>>>>>> 6bf09e7b0729bf24deb5b7330c89a94496998304
using LojaProdutos.Services.Produto;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddScoped<IProdutoInterface, ProdutoService>();
<<<<<<< HEAD
builder.Services.AddScoped<ICategoriaInterface, CategoriaService>();
=======
>>>>>>> 6bf09e7b0729bf24deb5b7330c89a94496998304

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
