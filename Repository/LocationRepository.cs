using EasyWeather.Models.Weather.Location;
using EasyWeather.Service.DTO.Location;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Newtonsoft.Json;

public class LocationRepository
{
    private const string URI_API = "http://api.openweathermap.org/geo/1.0/direct";
    private readonly HttpService HTTPService;

    public LocationRepository()
    {
        if (HTTPService == null) HTTPService = HttpService.Instance;
    }

    public async Task<List<LocationDto>?> GetLocationsByName(string query, int limit=10)
    {
        query = query
            .Replace(";", ",")
            .Replace("_", ",")
            .Replace("-", ",");

        var parameters = new Dictionary<string, string>
        {
            { "q", query },
            { "limit", limit.ToString() },
        };

        string response = await HTTPService.GET(URI_API, parameters);
        List<LocationDto> dtoList = LocationDto.LocationsFromOpenWeatherJson(response);

        return dtoList;
    }
}

