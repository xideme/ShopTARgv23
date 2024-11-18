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

        public async Task<IActionResult> Index()
        {
            var listGames = await _freeToPlayServices.FreeToPlayResult();

            var viewModelList = listGames.Select(Game => new FreeToPlayViewModel
            {

                Id = Game.Id,
                Title = Game.Title,
                Thumbnail = Game.Thumbnail,
                ShortDescription = Game.ShortDescription,
                GameUrl = Game.GameUrl,
                Genre   = Game.Genre,
                Platform = Game.Platform,
                Publisher = Game.Publisher,
                Developer = Game.Developer,
                ReleaseDate = Game.ReleaseDate,
                FreetogameProfileUrl = Game.FreetogameProfileUrl,


            }).ToList();
            return View(viewModelList);
        }


        //[HttpPost]
        //public IActionResult SearchGame(FreeToPlayViewModel model)
        //{
        //    return RedirectToAction(nameof(Game));
        //}

        //[HttpGet]

        //public IActionResult Game()

        //{
        //    FreeToPlayResultDto dto = new();

        //    //_freeToPlayServices.FreeToPlayResult(dto);
        //    FreeToPlayViewModel vm = new();


        //    vm.Id = dto.Id;
        //    vm.Title = dto.Title;
        //    vm.Thumbnail = dto.Thumbnail;
        //    vm.ShortDescription = dto.ShortDescription;
        //    vm.GameUrl = dto.GameUrl;
        //    vm.Genre = dto.Genre;
        //    vm.Platform = dto.Platform;
        //    vm.Publisher = dto.Publisher;
        //    vm.Developer = dto.Developer;
        //    vm.ReleaseDate = dto.ReleaseDate;
        //    vm.FreetogameProfileUrl = dto.FreetogameProfileUrl;

        //    return View(vm);

        //}
    }
}
