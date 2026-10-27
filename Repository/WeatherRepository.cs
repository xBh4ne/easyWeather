
using EasyWeather.Models.Weather;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Collections.Generic;


public class WeatherRepository
{
    private const string HOURLY_URI_API = "https://pro.openweathermap.org/data/2.5/forecast/hourly";
    private readonly HttpService HTTPService;

    public WeatherRepository()
    {
        if (HTTPService == null) HTTPService = HttpService.Instance;
    }

    public async Task<Forecast?> GetForecastByCoordinates(double latitude, double longitude)
    {
        var parameters = new Dictionary<string, string>
    {
        { "lon", longitude.ToString(System.Globalization.CultureInfo.InvariantCulture) },
        { "lat", latitude.ToString(System.Globalization.CultureInfo.InvariantCulture) },
    };

        var response = await HTTPService.GET(HOURLY_URI_API, parameters);
        var forecast = Forecast.FromOpenWeatherJson(response);

        return forecast;
    }

}

