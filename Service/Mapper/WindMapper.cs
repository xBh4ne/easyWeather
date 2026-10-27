using EasyWeather.Models.Weather;
using EasyWeather.Service.DTO.Wind;

namespace EasyWeather.Service.Mapper;

public class WindMapper : IMapper<Wind, WindDto>
{
    public WindDto ToDto(Wind obj)
    {
        return new WindDto(
            obj.Speed,
            obj.Gusts,
            obj.Direction
        );
    }

    public Wind ToObject(WindDto dto)
    {
        return new Wind(
            dto.Speed,
            dto.Gusts,
            dto.Direction
        );
    }
}