using EasyWeather.Models.Weather;
using EasyWeather.Service.DTO;

namespace EasyWeather.Service.Mapper;

public class TemperatureMapper : IMapper<Temperature, TemperatureDto>
{
    public TemperatureDto ToDto(Temperature obj)
    {
        return new TemperatureDto(
            obj.Current,
            obj.Min,
            obj.Max,
            obj.FeelsLike
        );
    }

    public Temperature ToObject(TemperatureDto dto)
    {
        return new Temperature(
            dto.Current,
            dto.Min,
            dto.Max,
            dto.FeelsLike
        );
    }
}