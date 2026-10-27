using EasyWeather.Models.Weather.Location;
using EasyWeather.Service.DTO.Location;
using EasyWeather.Service.Mapper;

public class CordinatesMapper : IMapper<Coordinates, CoordinatesDTO>
{
    public CoordinatesDTO ToDto(Coordinates obj)
    {
        return new CoordinatesDTO(
                obj.Latitude,
                obj.Longitude
            );
    }

    public Coordinates ToObject(CoordinatesDTO dto)
    {
        return new Coordinates(
                dto.Latitude,
                dto.Longitude
            );
     }
}