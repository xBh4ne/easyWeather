namespace EasyWeather.Models.Weather;

public class Wind(double speed, double gusts, int direction)
{
    public double Speed
    {
        get;
        private set;
    } = speed;

    public double Gusts
    {
        get;
        private set;
    } = gusts;

    public int Direction
    {
        get;
        private set;
    } = direction;
}