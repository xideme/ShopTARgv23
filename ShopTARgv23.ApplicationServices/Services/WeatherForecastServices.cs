using Nancy.Json;
using ShopTARgv23.Core.Dto.WeatherDtos;
using ShopTARgv23.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace ShopTARgv23.ApplicationServices.Services
{
    public class WeatherForecastServices : IWeatherForecastServices
    {

        public async Task<AccuLocationWeatherResultDto> AccuWeatherResult(AccuLocationWeatherResultDto dto)
        {
            string accuApiKey = "AKuS67HdRmwN4xMwfcgTYv3reH8U4bBG";
            string url = $"http://dataservice.accuweather.com/locations/v1/cities/search?apikey={accuApiKey}&q={dto.CityName}";


            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                List<AccuLocationRootDto> accuResult = new JavaScriptSerializer().Deserialize<List<AccuLocationRootDto>>(json);


                //127964
                dto.CityName = accuResult[0].LocalizedName;
                dto.CityCode = accuResult[0].Key;
                dto.Rank = accuResult[0].Rank;

            }

            string urlWeather = $"http://dataservice.accuweather.com/forecasts/v1/daily/1day/{dto.CityCode}?apikey={accuApiKey}";

            return dto;


        }
    }
}
