using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace EasyWeather.Service.DTO.Location;

public class LocationDto
{
    public string Name { get; private set; }
    public string Country { get; private set; }
    public CoordinatesDTO Coordinates { get; private set; }

    public LocationDto() { }

    // Costruttore con parametri
    public LocationDto(string name, string country, CoordinatesDTO coordinates)
    {
        Name = name;
        Country = country ?? "";
        Coordinates = coordinates;
    }

    public static LocationDto fromJson(string json)
    {
        if (string.IsNullOrEmpty(json) || string.Equals(json, "{}"))
        {
            return null;
        }

        var settings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        return JsonConvert.DeserializeObject<LocationDto>(json, settings);
    }

    public static List<LocationDto> LocationsFromOpenWeatherJson(string json)
    {
        if (string.IsNullOrEmpty(json) || string.Equals(json, "{}"))
        {
            return new List<LocationDto>();
        }

        var openWeatherLocationDict = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(json);
        List<LocationDto> locations = new List<LocationDto>();

        if (openWeatherLocationDict != null)
        {
            foreach (Dictionary<string, object> location in openWeatherLocationDict)
            {
                CoordinatesDTO coordinates;

                if (location.TryGetValue("coord", out object? value)) {
                    coordinates = new CoordinatesDTO(
                        latitude: ((Dictionary<string, double>)value)["lat"],
                        longitude:((Dictionary<string, double>)value)["lon"]
                    );
                } else
                {
                    coordinates = new CoordinatesDTO(
                        latitude: (double)location["lat"],
                        longitude: (double)location["lon"]
                    );
                }
                LocationDto locationDTO = new LocationDto(
                    name: location["name"].ToString(),
                    country: location["country"].ToString(),
                    coordinates: coordinates
                );

                locations.Add(locationDTO);
            }
        }

        return locations; // Can be empty
    }
    
    public static LocationDto LocationFromOpenWeatherJson(string json)
    {
        if (string.IsNullOrEmpty(json) || string.Equals(json, "{}"))
        {
            return null;
        }

        var openWeatherLocationDict = JObject.Parse(json);
        LocationDto locationDTO = null;
        if (openWeatherLocationDict != null)
        {
                CoordinatesDTO coordinates;
                var city = openWeatherLocationDict["city"];
                
                Console.WriteLine(city);
                if (city["coord"] != null) {
                    if (city["coord"]["lat"] != null && city["coord"]["lon"] != null)
                    {
                        coordinates = new CoordinatesDTO(
                            latitude: (double)city["coord"]["lat"],
                            longitude: (double)city["coord"]["lon"]
                        );
                    }
                    else
                    {
                        coordinates = new CoordinatesDTO(
                            latitude: 0,
                            longitude: 0
                        );
                    }
                    locationDTO = new LocationDto(
                        name: city["name"].ToString(),
                        country: city["country"].ToString(),
                        coordinates: coordinates
                    );
                } else
                {
                    coordinates = new CoordinatesDTO(
                        latitude: (double)openWeatherLocationDict["lat"],
                        longitude: (double)openWeatherLocationDict["lon"]
                    );
                    
                    locationDTO = new LocationDto(
                        name: openWeatherLocationDict["name"].ToString(),
                        country: openWeatherLocationDict["country"].ToString(),
                        coordinates: coordinates
                    );
                }
        }

        return locationDTO; // Can be empty
    }

    public string ToJson() {

        var settings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        return JsonConvert.SerializeObject(this, settings);
    }
}