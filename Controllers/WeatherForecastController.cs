using Microsoft.AspNetCore.Mvc;
using WebApplication3OT.Services.Interfaces;

namespace WebApplication3OT.Controllers
{
    public class WeatherForecastController : Controller
    {
        private readonly IWeatherForecastService _service;

        public WeatherForecastController(IWeatherForecastService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public async Task<IActionResult> Index()
        {
            var products = await _service.Find();
            return View(products);
        }
    }
}
