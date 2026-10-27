
using System.Xml.Linq;
using EasyWeather.Views.Weather;
using Microsoft.AspNetCore.Mvc;

namespace EasyWeather.Controllers
{

    [Route("weather")]
    public class WeatherController : Controller
    {
        private WeatherRepository weatherRepository = new WeatherRepository();
        
        // Get Hourly Forecast By Corrdinates 
        [Route("")]
        public ActionResult Index(double latitude, double longitude)
        {
            Console.WriteLine("latitude: " + latitude);
            Console.WriteLine("longitude: " + longitude);
            var forecast = weatherRepository.GetForecastByCoordinates(latitude, longitude).GetAwaiter().GetResult();
            
            var viewModel = new HourlyForecastByCoordinatesModel
            {
                Forecast = forecast,
            };
            
            return View(viewModel);
        }


        // Endpoint returns JSON Hourly Forecast by Coordinates
        [Route("get")]
        public ContentResult HourlyForecastByCoordinates(double latitude, double longitude)
        {
            var forecast = weatherRepository.GetForecastByCoordinates(latitude, longitude).GetAwaiter().GetResult();

            var weathersXml = new XElement("Weathers");

            foreach (var weather in forecast.Weathers)
            {
                weathersXml.Add(
                    new XElement(
                        "Weather", 
                            new XAttribute("deltaTime", weather.DeltaTime.ToString()),
                            new XAttribute("description", weather.Description),
                            new XElement("Wind", 
                                new XAttribute("speed", weather.Wind.Speed.ToString()),
                                new XAttribute("direction", weather.Wind.Direction.ToString()),
                                new XAttribute("gust", weather.Wind.Gusts.ToString())
                                ),
                            new XElement("Cloud",
                                new XAttribute("cloudiness", weather.Cloudiness)),
                            new XElement("Temperature", 
                                new XAttribute("current", weather.Temperature.Current.ToString()),
                                new XAttribute("min", weather.Temperature.Min.ToString()),
                                new XAttribute("max", weather.Temperature.Max.ToString()),
                                new XAttribute("feelsLike", weather.Temperature.FeelsLike.ToString())
                                ),
                            new XElement("Humidity", 
                                new XAttribute("value", weather.Humidity.ToString())
                            ),
                            new XElement("Visibility", 
                                new XAttribute("value", weather.Visibility.ToString())
                            ),
                            new XElement("Precipitation", 
                                new XAttribute("percentege", weather.ProbabilityPrecipitation.ToString()),
                                new XAttribute("rain1h", weather.Rain1H.ToString()),
                                new XAttribute("snow1h", weather.Snow1H.ToString())
                            )
                        )
                    );
            }
            
            var forecastXml = new XElement("Forecast",
                new XAttribute("sunset", forecast.Sunrise.ToString()),
                new XAttribute("sunrise", forecast.Sunset.ToString()),
                new XElement("Location", 
                    new XAttribute("name", forecast.Location.Name),
                    new XAttribute("country", forecast.Location.Country),
                    new XElement("Coordinates",
                        new XAttribute("longitude", forecast.Location.Coordinates.Longitude.ToString()),
                        new XAttribute("latitude", forecast.Location.Coordinates.Latitude.ToString())
                        )
                    ),
                weathersXml
                ); 
            return Content(forecastXml.ToString(), "application/xml");
        }
    }
}

/*
 
File Json:

{
    'clienti':
        [
            'Mario',
            'Fabio'
        ]
}

File Xml:

<Clienti>
    <Cliente nome="Mario">
    <Cliente nome="Fabio">
</Clienti>

 */
