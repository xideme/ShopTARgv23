using Microsoft.AspNetCore.Mvc;
using ShopTARgv23.Core.ServiceInterface;
using ShopTARgv23.Data;
using ShopTARgv23.Models.Kindergartens;
using ShopTARgv23.Models.RealEstates;

namespace ShopTARgv23.Controllers
{
    public class RealEstatesController : Controller
    {
        private readonly ShopTARgv23Context _context;
        private readonly IRealEstateServices _irealestateServices;

        public RealEstatesController
            (
                ShopTARgv23Context context,
                IRealEstateServices realestateServices
            )
        {
            _context = context;
            _irealestateServices = realestateServices;
        }

        public IActionResult Index()
        {
            var result = _context.RealEstates
                .Select(x => new RealEstatesIndexViewModel
                {
                    Id = x.Id,
                    Location = x.Location,
                    Size = x.Size,
                    RoomNumber = x.RoomNumber,
                    BuildingType = x.BuildingType
                });

            return View(result);
        }

    }
}
