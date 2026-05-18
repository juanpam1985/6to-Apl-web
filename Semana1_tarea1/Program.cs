using System.Globalization;
using Semana1_Tarea1.Services;

var builder = WebApplication.CreateBuilder(args);

// Configuración regional para Ecuador.
var cultureInfo = new CultureInfo("es-EC");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

// MVC
builder.Services.AddControllersWithViews();

// Inyección de dependencias aplicando el principio de inversión de dependencias.
builder.Services.AddScoped<ICalculadoraService, CalculadoraService>();

var app = builder.Build();

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
