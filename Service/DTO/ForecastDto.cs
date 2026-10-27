using EasyWeather.Service.DTO.Location;
using EasyWeather.Service.Mapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EasyWeather.Service.DTO;

public class ForecastDto(List<WeatherDto> weathers, LocationDto location, long sunset, long sunrise)
{
    public List<WeatherDto> Weathers { get; } = weathers;
    public LocationDto Location { get; } = location;
    public long Sunset { get; } = sunset;
    public long Sunrise { get; } = sunrise;
    
    public static ForecastDto FromOpenWeatherJson(string json)
    {
        if (string.IsNullOrEmpty(json) || string.Equals(json, "{}"))
        {
            return null;
        }

        var forecastJson = JObject.Parse(json);
        var locationDTO = LocationDto.LocationFromOpenWeatherJson(json);
        var info = forecastJson["city"];
        var sunrise = Convert.ToInt64(info["sunrise"]);
        var sunset = Convert.ToInt64(info["sunset"]);
        
        var weatherList = forecastJson["list"].ToList();
        var weathers = new List<WeatherDto>();

        foreach (var weatherEntry in weatherList)
        {
            var weatherDto = WeatherDto.FromOpenWeatherJson(weatherEntry.ToString());
            weathers.Add(weatherDto);
        }

        return new ForecastDto(weathers, locationDTO, sunset, sunrise);
    }

    public string ToJson()
    {
        return JsonConvert.SerializeObject(this);
    }
}