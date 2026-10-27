namespace EasyWeather.Models.Weather.Location
{
    public class Location(string name, string country, Coordinates coordinates)
    {
        public string Name
        {
            get;
            private set;
        } = name;

        public string Country
        {
            get;
            private set;
        } = country;

        public Coordinates Coordinates
        {
            get;
            private set;
        } = coordinates;
        
    }
}
