using Microsoft.AspNetCore.Mvc;
using ShopTARgv23.Core.ServiceInterface;
using ShopTARgv23.Models.AccuWeathers;
using ShopTARgv23.Models.Cocktails;

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

        public async Task<IActionResult> Index()
        {
            //var listCocktails = await _cocktailsServices.CocktailsResult();

            

            //var viewModelList = listCocktails.Select (Cocktail )

            return View();
        }

        [HttpPost]
        public IActionResult SearchCocktail(CocktailsSearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Cocktail", "Cocktails", new { cocktail = model.strDrink });
            }

            return View(model);
        }

    }
}
