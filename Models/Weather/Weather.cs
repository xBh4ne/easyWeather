namespace EasyWeather.Models.Weather;

public class Weather(
    long deltaTime,
    Wind wind,
    int cloudiness,
    Temperature temperature,
    int humidity,
    long visibility,
    double probabilityPrecipitation,
    double rain1H,
    double snow1H,
    string description
    )
{
    public long DeltaTime { get; } = deltaTime;
    public Wind Wind { get; } = wind;
    public int Cloudiness { get; } = cloudiness;
    public Temperature Temperature { get; } = temperature;
    public int Humidity { get; } = humidity;
    public long Visibility { get; } = visibility;
    public double ProbabilityPrecipitation { get; } = probabilityPrecipitation;
    public double Rain1H { get; } = rain1H;
    public double Snow1H { get; } = snow1H;
    public string Description { get; } = description;
}