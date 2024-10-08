using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ShopTARgv23.Core.Domain;
using ShopTARgv23.Core.Dto;
using ShopTARgv23.Core.ServiceInterface;
using ShopTARgv23.Data;

namespace ShopTARgv23.ApplicationServices.Services
{
    public class RealEstatesServices : IRealEstateServices
    {
        private readonly ShopTARgv23Context _context;
        private readonly IFileServices _fileServices;

        public RealEstatesServices
            (
                ShopTARgv23Context context,
                IFileServices fileServices
            )
        {
            _context = context;
            _fileServices = fileServices;

        }

        public async Task<RealEstate> DetailsAsync(Guid id)
        {
            var result = await _context.RealEstates
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<RealEstate> Create(RealEstateDto dto)
        {
            RealEstate realestate = new();

            realestate.Id = Guid.NewGuid();
            realestate.Location = dto.Location;
            realestate.Size = dto.Size;
            realestate.RoomNumber = dto.RoomNumber;
            realestate.BuildingType = dto.BuildingType;
            realestate.CreatedAt = DateTime.Now;
            realestate.ModifiedAt = DateTime.Now;


            if (dto.Files != null)
            {
                _fileServices.UploadFilesToDatabase(dto, realestate);
            }

            await _context.RealEstates.AddAsync(realestate);
            await _context.SaveChangesAsync();

            return realestate;

        }


        public async Task<RealEstate> Update(RealEstateDto dto)
        {
            RealEstate domain = new();

            domain.Id = dto.Id;
            domain.Location = dto.Location;
            domain.Size = dto.Size;
            domain.RoomNumber = dto.RoomNumber;
            domain.BuildingType = dto.BuildingType;
            domain.CreatedAt = dto.CreatedAt;
            domain.ModifiedAt = DateTime.Now;

            _context.RealEstates.Update(domain);
            await _context.SaveChangesAsync();

            return domain;
        }

        public async Task<RealEstate> Delete(Guid id)
        {
            var realestate = await _context.RealEstates
                .FirstOrDefaultAsync(x => x.Id == id);

            _context.RealEstates.Remove(realestate);
            await _context.SaveChangesAsync();

            return realestate;
        }
    }
}
