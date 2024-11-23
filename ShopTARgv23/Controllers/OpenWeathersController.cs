using Microsoft.AspNetCore.Mvc;
using ShopTARgv23.Core.Dto.OpenWeatherDto;
using ShopTARgv23.Core.ServiceInterface;
using ShopTARgv23.Models.OpenWeathers;

namespace ShopTARgv23.Controllers
{
    public class OpenWeathersController : Controller
    {
        private readonly IOpenWeatherServices _openWeatherServices;

        public OpenWeathersController(IOpenWeatherServices openWeatherServices)
        {
            _openWeatherServices = openWeatherServices;
        }



        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult SearchCity(OpenWeatherSearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Redirect to the City action with the searched city as a parameter
                return RedirectToAction("City", "OpenWeather", new { city = model.Name });
            }

            // If the model state is invalid, return the current view
            return View(model);
        }

        // GET action to show the weather details for the city
        [HttpGet]
        public IActionResult City(string city)
        {
            OpenWeatherResultDto dto = new OpenWeatherResultDto
            {
                Name = city // Assign city name from the query parameter
            };

            // Get weather data using the service
            _openWeatherServices.OpenWeatherResult(dto);

            // Create a view model to pass data to the view
            OpenWeatherViewModel vm = new OpenWeatherViewModel
            {
                Name = dto.Name,
                Temp = dto.Main.Temp,
                TempMin = dto.Main.TempMin,
                TempMax = dto.Main.TempMax,
                Description = dto.Weather[0].Description,
                WindSpeed = dto.Wind.Speed,
                WeatherIcon = dto.Weather[0].Icon
            };

            // Return the view with the populated view model
            return View(vm);
        }
    }

}
