﻿using Microsoft.AspNetCore.Mvc;
using ShopTARgv23.Core.Domain;
using ShopTARgv23.Core.Dto;
using ShopTARgv23.Core.ServiceInterface;
using ShopTARgv23.Data;
using ShopTARgv23.Models.Spaceships;
using System.Linq;

namespace ShopTARgv23.Controllers
{
    public class SpaceshipsController : Controller
    {
        private readonly ShopTARgv23Context _context;
        private readonly ISpaceshipServices _spaceshipServices;

        public SpaceshipsController
            (
                ShopTARgv23Context context,
                ISpaceshipServices spaceshipServices
            )
        {
            _context = context;
            _spaceshipServices = spaceshipServices;
        }

        public IActionResult Index()
        {
            var result = _context.Spaceships
                .Select(x => new SpaceshipsIndexViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Type = x.Type,
                    BuiltDate = x.BuiltDate,
                    EnginePower = x.EnginePower
                });

            return View(result);
        }

        [HttpGet]

        public IActionResult Create()
        {
            SpaceshipCreateUpdateViewModel spaceship = new();

            return View("CreateUpdate", spaceship);

        }

        [HttpPost]

        public async Task<IActionResult> Create(SpaceshipCreateUpdateViewModel vm)
        {
            var dto = new SpaceshipDto()
            {
                Id = vm.Id,
                Name = vm.Name,
                Type = vm.Type,
                BuiltDate = vm.BuiltDate,
                CargoWeight = vm.CargoWeight,
                Crew = vm.Crew,
                EnginePower = vm.EnginePower,
                Files = vm.Files,
                Image = vm.FileToApiViewModels
                    .Select( x=> new FileToApiDto
                    {
                        Id = x.ImageId,
                        ExistingFilePath = x.FilePath,
                        SpaceshipId = x.SpaceshipId,
                        

                    }).ToArray()

            };

            var result = await _spaceshipServices.Create(dto);

            if (result==null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);

        }


        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var spaceship = await _spaceshipServices.DetailsAsync(id);

            if (spaceship == null)
            {
                return NotFound();
            }

            var vm = new SpaceshipDetailsViewModel();

            vm.Id = spaceship.Id;
            vm.Name = spaceship.Name;
            vm.Type = spaceship.Type;
            vm.BuiltDate = spaceship.BuiltDate;
            vm.CargoWeight = spaceship.CargoWeight;
            vm.Crew = spaceship.Crew;
            vm.EnginePower = spaceship.EnginePower;
            vm.CreatedAt = spaceship.CreatedAt;
            vm.ModifiedAt = spaceship.ModifiedAt;

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var spaceship = await _spaceshipServices.DetailsAsync(id);

            if (spaceship == null)
            {
                return NotFound();
            }

            var vm = new SpaceshipCreateUpdateViewModel();

            vm.Id = spaceship.Id;
            vm.Name = spaceship.Name;
            vm.Type = spaceship.Type;
            vm.BuiltDate = spaceship.BuiltDate;
            vm.CargoWeight = spaceship.CargoWeight;
            vm.Crew = spaceship.Crew;
            vm.EnginePower = spaceship.EnginePower;
            vm.ModifiedAt = spaceship.ModifiedAt;
            vm.CreatedAt = spaceship.CreatedAt; 

            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(SpaceshipCreateUpdateViewModel vm)
        {
            var dto = new SpaceshipDto();

            dto.Id = vm.Id;
            dto.Name = vm.Name;
            dto.Type = vm.Type;
            dto.BuiltDate = vm.BuiltDate;
            dto.CargoWeight = vm.CargoWeight;
            dto.Crew = vm.Crew;
            dto.EnginePower = vm.EnginePower;
            dto.CreatedAt = vm.CreatedAt;
            dto.ModifiedAt = vm.ModifiedAt;

            var result = await _spaceshipServices.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var spaceship = await _spaceshipServices.DetailsAsync(id);

            if (spaceship == null)
            {
                return NotFound();
            }

            var vm = new SpaceshipDeleteViewModel();

            vm.Id = spaceship.Id;
            vm.Name = spaceship.Name;
            vm.Type = spaceship.Type;
            vm.BuiltDate = spaceship.BuiltDate;
            vm.CargoWeight = spaceship.CargoWeight;
            vm.Crew = spaceship.Crew;
            vm.EnginePower = spaceship.EnginePower;
            vm.CreatedAt = spaceship.CreatedAt;
            vm.ModifiedAt = spaceship.ModifiedAt;

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var spaceship = await _spaceshipServices.Delete(id);

            if(spaceship == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
