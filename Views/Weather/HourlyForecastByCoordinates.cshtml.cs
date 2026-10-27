using EasyWeather.Models.Weather;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EasyWeather.Views.Weather;

public class HourlyForecastByCoordinatesModel : PageModel
{
    public Forecast? Forecast { get; set;}
}