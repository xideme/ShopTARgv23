using Nancy.Json;
using ShopTARgv23.Core.Dto.WeatherDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARgv23.ApplicationServices.Services
{
    public class WeatherForecastServices
    {

        public async Task<AccuLocationWeatherResultDto> AccuWeatherResult(AccuLocationWeatherResultDto dto)
        {
            string accuApiKey = "AKuS67HdRmwN4xMwfcgTYv3reH8U4bBG";
            string url = $"http://dataservice.accuweather.com/locations/v1/cities/search?apikey={accuApiKey}&q={dto.CityName}";


            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                AccuLocationRootDto accuResult = new JavaScriptSerializer().Deserialize<AccuLocationRootDto>(json);
            }
            return dto;
        }
    }
}
