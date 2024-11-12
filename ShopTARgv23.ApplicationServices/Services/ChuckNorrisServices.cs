using Nancy.Json;
using ShopTARgv23.Core.Dto.ChuckNorrisRootDto;
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
    public class ChuckNorrisServices : IChuckNorrisServices
    {

        //chuck norrise api call

        //service class, interface, controller

            public async Task<ChuckNorrisResultDto> ChuckNorrisResult(ChuckNorrisResultDto dto)
            {
                var url = "https://api.chucknorris.io/jokes/random";

                using (WebClient client = new WebClient())
                {
                    string json = client.DownloadString(url);
                    ChuckNorrisRootDto chuckNorrisResult = new JavaScriptSerializer().Deserialize<ChuckNorrisRootDto>(json);

                    //dto.Categories = chuckNorrisResult.Categories[0];
                    dto.CreatedAt = chuckNorrisResult.CreatedAt;
                    dto.IconUrl = chuckNorrisResult.IconUrl;
                    dto.Id = chuckNorrisResult.Id;
                    dto.UpdatedAt = chuckNorrisResult.UpdatedAt;
                    dto.Url = chuckNorrisResult.Url;
                    dto.Value = chuckNorrisResult.Value;
                }

                return dto;


        }
    }
}
