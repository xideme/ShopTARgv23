using Nancy.Json;
using ShopTARgv23.Core.Dto.FreeToPlayRootDto;
using ShopTARgv23.Core.Dto.WeatherDtos;
using ShopTARgv23.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARgv23.ApplicationServices.Services
{
    public class FreeToPlayServices : IFreeToPlayServices
    {

        public async Task<FreeToPlayResultDto> FreeToPlayResult(FreeToPlayResultDto dto)
        {

            string url = $"https://www.freetogame.com/api/games";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                List<FreeToPlayRootDto> freetoplayResult = new JavaScriptSerializer()
                    .Deserialize<List<FreeToPlayRootDto>>(json);

                dto.Id = freetoplayResult[0].Id;
                dto.Title = freetoplayResult[0].Title;
                dto.Thumbnail = freetoplayResult[0].Thumbnail;
                dto.ShortDescription = freetoplayResult[0].ShortDescription;
                dto.GameUrl = freetoplayResult[0].GameUrl;
                dto.Genre = freetoplayResult[0].Genre;
                dto.Platform = freetoplayResult[0].Platform;
                dto.Publisher = freetoplayResult[0].Publisher;
                dto.Developer = freetoplayResult[0].Developer;
                dto.ReleaseDate = freetoplayResult[0].ReleaseDate;
                dto.FreetogameProfileUrl = freetoplayResult[0].FreetogameProfileUrl;


            }

            return dto;
        }

    }
}
