using EasyWeather.Service.DTO;
using EasyWeather.Service.Mapper;

namespace EasyWeather.Models.Weather;

public class Forecast(List<Weather> weathers, Location.Location location, long sunset, long sunrise)
{
    public List<Weather> Weathers { get; } = weathers;
    public Location.Location Location { get; } = location;
    public long Sunset { get; } = sunset;
    public long Sunrise { get; } = sunrise;
    
    public static Forecast FromOpenWeatherJson(string json)
    {
        var forecastDto = ForecastDto.FromOpenWeatherJson(json);
        return new ForecastMapper().ToObject(forecastDto);
    }

    public string ToJson()
    {
        return new ForecastMapper().ToDto(this).ToJson();
    }
}