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

        public async Task<List<FreeToPlayRootDto>> FreeToPlayResult()
        {

            string url = $"https://www.freetogame.com/api/games";
            List<FreeToPlayRootDto> gameList = new List<FreeToPlayRootDto>();

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                var result = new JavaScriptSerializer()
                    .Deserialize<List<FreeToPlayRootDto>>(json);

                if (result != null)
                {
                    gameList.AddRange(result);

                }
                
            }

            return gameList;
        }

    }
}
