using WebApplication3OT.Models;

namespace WebApplication3OT.Services.Interfaces
{
    public interface IWeatherForecastService
    {
        Task<IEnumerable<WeatherForecast>> Find();
    }
}
