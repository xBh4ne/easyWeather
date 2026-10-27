using EasyWeather.Models.Weather;
using EasyWeather.Service.DTO;

namespace EasyWeather.Service.Mapper;

public class WeatherMapper : IMapper<Weather, WeatherDto>
{
    private readonly WindMapper _windMapper = new WindMapper();
    private readonly TemperatureMapper _temperatureMapper = new TemperatureMapper();
    private readonly LocationMapper _locationMapper = new LocationMapper();

    public WeatherDto ToDto(Weather obj)
    {
        return new WeatherDto(
            deltaTime: obj.DeltaTime,
            wind: _windMapper.ToDto(obj.Wind),
            temperature: _temperatureMapper.ToDto(obj.Temperature),
            cloudiness: obj.Cloudiness,
            humidity: obj.Humidity,
            visibility: obj.Visibility,
            probabilityPrecipitation: obj.ProbabilityPrecipitation,
            rain1H: obj.Rain1H,
            snow1H: obj.Snow1H,
            description: obj.Description
        );
    }

    public Weather ToObject(WeatherDto dto)
    {
        return new Weather(
            deltaTime: dto.DeltaTime,
            wind: _windMapper.ToObject(dto.Wind),
            temperature: _temperatureMapper.ToObject(dto.Temperature),
            cloudiness: dto.Cloudiness,
            humidity: dto.Humidity,
            visibility: dto.Visibility,
            probabilityPrecipitation: dto.ProbabilityPrecipitation,
            rain1H: dto.Rain1H,
            snow1H: dto.Snow1H,
            description: dto.Description
        );
    }
}