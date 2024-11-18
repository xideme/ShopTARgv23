using Microsoft.AspNetCore.Mvc;
using ShopTARgv23.Core.ServiceInterface;

namespace ShopTARgv23.Controllers
{
    public class CocktailsController : Controller
    {

        private readonly ICocktailsServices _cocktailsServices;

        public CocktailsController
            (
                ICocktailsServices cocktailsServices
            )
        {
            _cocktailsServices = cocktailsServices;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
