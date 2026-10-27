using EasyWeather.Models.Weather.Location;
using EasyWeather.Service.DTO.Location;
using EasyWeather.Service.Mapper;

public class LocationMapper : IMapper<Location, LocationDto>
{
    private CordinatesMapper cordinatesMapper = new CordinatesMapper();

    public LocationDto ToDto(Location obj)
    {
        return new LocationDto(
                name: obj.Name,
                country: obj.Country,
                coordinates: cordinatesMapper.ToDto(obj.Coordinates)
            );
    }

    public Location ToObject(LocationDto dto)
    {
        return new Location(
                name: dto.Name,
                country: dto.Country,
                coordinates: cordinatesMapper.ToObject(dto.Coordinates)
            );
     }
}

