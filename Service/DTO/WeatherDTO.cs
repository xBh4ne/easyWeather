using EasyWeather.Service.DTO.Wind;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EasyWeather.Service.DTO;

public class WeatherDto(
    long deltaTime,
    WindDto wind,
    int cloudiness,
    TemperatureDto temperature,
    int humidity,
    long visibility,
    double probabilityPrecipitation,
    double rain1H,
    double snow1H,
    string description
    )
{
    public long DeltaTime { get; } = deltaTime;
    public WindDto Wind { get; } = wind;
    public int Cloudiness { get; } = cloudiness;
    public TemperatureDto Temperature { get; } = temperature;
    public int Humidity { get; } = humidity;
    public long Visibility { get; } = visibility;
    public double ProbabilityPrecipitation { get; } = probabilityPrecipitation;
    public double Rain1H { get; } = rain1H;
    public double Snow1H { get; } = snow1H;
    public string Description { get; } = description;

    public static WeatherDto FromOpenWeatherJson(string json)
    {
        if (string.IsNullOrEmpty(json) || string.Equals(json, "{}"))
        {
            return null;
        }

        WeatherDto weatherDto = null;

        var openWeatherWeatherDict = JObject.Parse(json);
        
            var deltaTime = (long)openWeatherWeatherDict["dt"];

            // Wind
            var speed = (double)openWeatherWeatherDict["wind"]["speed"];
            var direction = (int)openWeatherWeatherDict["wind"]["deg"];
            var gusts = (double)openWeatherWeatherDict["wind"]["gust"];
            var wind = new WindDto(speed: speed, direction: direction, gusts: gusts);

            // Cloud
            var cloudiness = (int)openWeatherWeatherDict["clouds"]["all"];

            // Temperature
            var current = (double)openWeatherWeatherDict["main"]["temp"];
            var min = (double)openWeatherWeatherDict["main"]["temp_min"];
            var max = (double)openWeatherWeatherDict["main"]["temp_max"];
            var feelsLike = (double)openWeatherWeatherDict["main"]["feels_like"];

            current = Double.Round(current - 273.15, 2);
            min = Double.Round(min - 273.15, 2);
            max = Double.Round(max - 273.15, 2);
            feelsLike = Double.Round(feelsLike - 273.15, 2);
            
            var temperature = new TemperatureDto(current: current, min: min, max: max, feelsLike: feelsLike);

            // Humidity
            var humidity = (int)openWeatherWeatherDict["main"]["humidity"];

            // Visibility
            var visibility = (long) (openWeatherWeatherDict["visibility"] ?? -1);

            // Precipitation
            var probabilityPrecipitation = (double)openWeatherWeatherDict["pop"];
            var rain1H = -999.9;
            var snow1H = -999.9;
            
            if (openWeatherWeatherDict["rain"] != null) {
                rain1H = (double)openWeatherWeatherDict["rain"]["1h"];
            }
            
            if (openWeatherWeatherDict["snow"] != null) {
                snow1H =  (double)openWeatherWeatherDict["snow"]["1h"];
            }
            

            // Description
            var description = (string)openWeatherWeatherDict["weather"][0]["description"];
            
            weatherDto = new WeatherDto(
                deltaTime: deltaTime,
                wind: wind,
                cloudiness: cloudiness,
                temperature: temperature,
                humidity: humidity,
                visibility: visibility,
                probabilityPrecipitation: probabilityPrecipitation,
                rain1H: rain1H,
                snow1H: snow1H,
                description: description
            );
            
        return weatherDto;
    }
    
}