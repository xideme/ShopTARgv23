using Microsoft.AspNetCore.Mvc;
using ShopTARgv23.Core.Dto.FreeToPlayRootDto;
using ShopTARgv23.Core.ServiceInterface;
using ShopTARgv23.Models.ChuckNorris;
using ShopTARgv23.Models.FreeToPlay;

namespace ShopTARgv23.Controllers
{
    public class FreeToPlayController : Controller
    {

        private readonly IFreeToPlayServices _freeToPlayServices;

        public FreeToPlayController
            (
                IFreeToPlayServices freeToPlayServices
            )
        {
            _freeToPlayServices = freeToPlayServices;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult SearchGame(FreeToPlayViewModel model)
        {
            return RedirectToAction(nameof(Game));
        }

        [HttpGet]

        public IActionResult Game()

        {
            FreeToPlayResultDto dto = new();

            _freeToPlayServices.FreeToPlayResult(dto);
            FreeToPlayViewModel vm = new();


            vm.Id = dto.Id;
            vm.Title = dto.Title;
            vm.Thumbnail = dto.Thumbnail;
            vm.ShortDescription = dto.ShortDescription;
            vm.GameUrl = dto.GameUrl;
            vm.Genre = dto.Genre;
            vm.Platform = dto.Platform;
            vm.Publisher = dto.Publisher;
            vm.Developer = dto.Developer;
            vm.ReleaseDate = dto.ReleaseDate;
            vm.FreetogameProfileUrl = dto.FreetogameProfileUrl;

            return View(vm);

        }
    }
}
