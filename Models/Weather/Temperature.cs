namespace EasyWeather.Models.Weather;

public class Temperature(double current, double min, double max, double feelsLike)
{
    public double Current
    {
        get;
        private set;
    } = current;

    public double Min
    {
        get;
        private set;
    } = min;

    public double Max
    {
        get;
        private set;
    } = max;

    public double FeelsLike
    {
        get;
        private set;
    } = feelsLike;
}