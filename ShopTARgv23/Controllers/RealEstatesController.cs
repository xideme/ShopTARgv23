using Microsoft.AspNetCore.Mvc;
using ShopTARgv23.ApplicationServices.Services;
using ShopTARgv23.Core.Dto;
using ShopTARgv23.Core.ServiceInterface;
using ShopTARgv23.Data;
using ShopTARgv23.Models.Kindergartens;
using ShopTARgv23.Models.RealEstates;

namespace ShopTARgv23.Controllers
{
    public class RealEstatesController : Controller
    {
        private readonly ShopTARgv23Context _context;
        private readonly IRealEstateServices _realestateServices;

        public RealEstatesController
            (
                ShopTARgv23Context context,
                IRealEstateServices realestateServices
            )
        {
            _context = context;
            _realestateServices = realestateServices;
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


        [HttpGet]

        public IActionResult Create()
        {
            RealEstateCreateUpdateViewModel realestate = new();

            return View("CreateUpdate", realestate);

        }

        [HttpPost]

        public async Task<IActionResult> Create(RealEstateCreateUpdateViewModel vm)
        {
            var dto = new RealEstateDto()
            {
                Id = vm.Id,
                Location = vm.Location,
                Size = vm.Size,
                RoomNumber = vm.RoomNumber,
                BuildingType = vm.BuildingType,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt,
                Files = vm.Files,
                Image = vm.Image
                    .Select(x => new FileToDatabaseDto
                    { 
                        Id = x.ImageId,
                        ImageData = x.ImageData,
                        ImageTitle = x.ImageTitle,
                        RealEstateId = x.RealEstateId

                    }).ToArray()


            };

            var result = await _realestateServices.Create(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);

        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var realestate = await _realestateServices.DetailsAsync(id);

            if (realestate == null)
            {
                return NotFound();
            }

            var vm = new RealEstateCreateUpdateViewModel();

            vm.Id = realestate.Id;
            vm.Location = realestate.Location;
            vm.Size = realestate.Size;
            vm.RoomNumber = realestate.RoomNumber;
            vm.BuildingType = realestate.BuildingType;
            vm.CreatedAt = realestate.CreatedAt;
            vm.ModifiedAt = realestate.ModifiedAt;

            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(RealEstateCreateUpdateViewModel vm)
        {
            var dto = new RealEstateDto();

            dto.Id = vm.Id;
            dto.Location = vm.Location;
            dto.Size = vm.Size;
            dto.RoomNumber = vm.RoomNumber;
            dto.BuildingType = vm.BuildingType;
            dto.CreatedAt = vm.CreatedAt;
            dto.ModifiedAt = vm.ModifiedAt;

            var result = await _realestateServices.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var realestate = await _realestateServices.DetailsAsync(id);

            if (realestate == null)
            {
                return NotFound();
            }

            var vm = new RealEstateDetailsViewModel();

            vm.Id = realestate.Id;
            vm.Location = realestate.Location;
            vm.Size = realestate.Size;
            vm.RoomNumber = realestate.RoomNumber;
            vm.BuildingType = realestate.BuildingType;
            vm.CreatedAt = realestate.CreatedAt;
            vm.ModifiedAt = realestate.ModifiedAt;

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var realestate = await _realestateServices.DetailsAsync(id);

            if (realestate == null)
            {
                return NotFound();
            }

            var vm = new RealEstateDeleteViewModel();

            vm.Id = realestate.Id;
            vm.Location = realestate.Location;
            vm.Size = realestate.Size;
            vm.RoomNumber = realestate.RoomNumber;
            vm.BuildingType = realestate.BuildingType;
            vm.CreatedAt = realestate.CreatedAt;
            vm.ModifiedAt = realestate.ModifiedAt;

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var realestate = await _realestateServices.Delete(id);

            if (realestate == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
