using EasyWeather.Models.Weather.Location;
using EasyWeather.Service.DTO.Location;
using Microsoft.AspNetCore.Mvc;

namespace EasyWeather.Controllers
{
    [Route("location")]
    public class LocationController : Controller
    {
        LocationRepository locationRepository = new LocationRepository();
        // GET: LocationController
        public RedirectResult Index()
        {
            return Redirect("/");
        }
        
        [Route("get")]
        public ActionResult List(string q, int limit=10)
        {
            if (string.IsNullOrEmpty(q) || q.Contains('>') || q.Contains('<')) return Ok("[]");

            List<LocationDto> locations = locationRepository.GetLocationsByName(q, limit).GetAwaiter().GetResult();

            Console.WriteLine("query: " + q);
            Console.WriteLine("results: ");
            foreach (var location in locations)
            {
                Console.WriteLine(location.Name);
            }

            return Ok(locations);

            
        }
    }
}
