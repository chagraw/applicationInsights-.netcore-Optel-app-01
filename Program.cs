using Azure.Monitor.OpenTelemetry.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApplication3OT.Data;
using WebApplication3OT.Services.Interfaces;
using WebApplication3OT.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<WebApplication3OTContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebApplication3OTContext") ?? throw new InvalidOperationException("Connection string 'WebApplication3OTContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddOpenTelemetry().UseAzureMonitor();
builder.Services.AddHttpClient<IWeatherForecastService, WeatherForecastService>(c =>
c.BaseAddress = new Uri("https://webappdemodncopttlin.azurewebsites.net/"));
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
