namespace EasyWeather.Service.DTO.Location
{
    public class CoordinatesDTO(double latitude, double longitude)
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
