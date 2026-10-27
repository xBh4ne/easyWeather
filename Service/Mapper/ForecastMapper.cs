using EasyWeather.Models.Weather;
using EasyWeather.Service.DTO;

namespace EasyWeather.Service.Mapper;

public class ForecastMapper : IMapper<Forecast, ForecastDto>
{
    public ForecastDto ToDto(Forecast obj)
    {
        List<WeatherDto> weathersDto = new List<WeatherDto>();

        foreach (var weather in obj.Weathers)
        {
            weathersDto.Add(new WeatherMapper().ToDto(weather));
        }
        
        return new ForecastDto(
            weathersDto,
            new LocationMapper().ToDto(obj.Location),
            obj.Sunset,
            obj.Sunrise
        );
    }

    public Forecast ToObject(ForecastDto dto)
    {
        List<Weather> weathers = new List<Weather>();

        foreach (var weather in dto.Weathers)
        {
            weathers.Add(new WeatherMapper().ToObject(weather));
        }
        
        return new Forecast(
            weathers,
            new LocationMapper().ToObject(dto.Location),
            dto.Sunset,
            dto.Sunrise
        );
    }
}