namespace EasyWeather.Service.DTO;

public class TemperatureDto(double current, double min, double max, double feelsLike)
{
    public double Current
    {
        get;
    } = current;

    public double Min
    {
        get;
    } = min;

    public double Max
    {
        get;
    } = max;

    public double FeelsLike
    {
        get;
    } = feelsLike;
}