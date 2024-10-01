using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ShopTARgv23.Core.Domain;
using ShopTARgv23.Core.Dto;
using ShopTARgv23.Core.ServiceInterface;
using ShopTARgv23.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARgv23.ApplicationServices.Services
{
    public class FileServices : IFileServices
    {
        private readonly ShopTARgv23Context _context;
        private readonly IHostEnvironment _webHost;



        public FileServices
            (
            ShopTARgv23Context context,
            IHostEnvironment webHost
            )

        {
            _context = context;
            _webHost = webHost;

        }


        public void FilesToApi(SpaceshipDto dto, Spaceship spaceship)
        {
            if (dto.Files != null && dto.Files.Count > 0)
            {
                if (!Directory.Exists(_webHost.ContentRootPath + "\\multipleFileUpload"))
                {
                    Directory.CreateDirectory(_webHost.ContentRootPath + "\\multipleFileUpload");
                }
            }

            foreach (var image in dto.Files)
            {
                string uploadsFolder = Path.Combine(_webHost.ContentRootPath, "multipleFileUpload");
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(fileStream);

                    FileToApi path = new FileToApi
                    {
                        Id = Guid.NewGuid(),
                        ExistingFilePath = uniqueFileName,
                        SpaceshipId = spaceship.Id
                    };



                    _context.FileToApis.AddAsync(path);
                }
            }
        }

    }
}
