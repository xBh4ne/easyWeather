namespace EasyWeather.Models.Weather.Location
{
    public class Coordinates(double latitude, double longitude)
    {
        public double Latitude
        {
            get;
            private set;
        } = latitude;

        public double Longitude
        {
            get;
            private set;
        } = longitude;
    }
}
