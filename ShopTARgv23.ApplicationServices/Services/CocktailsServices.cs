using DocumentFormat.OpenXml.Bibliography;
using Nancy.Json;
using ShopTARgv23.Core.Dto.CocktailsDto;
using ShopTARgv23.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARgv23.ApplicationServices.Services
{
    public class CocktailsServices : ICocktailsServices
    {

        public async Task<List<CocktailsRootDto>> CocktailsResult(CocktailsRootDto dto)
        {
            string url = $"www.thecocktaildb.com/api/json/v1/1/search.php?s={dto.drinks}";

            List<CocktailsRootDto> cocktailsList = new List<CocktailsRootDto>();

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                var result = new JavaScriptSerializer()
                    .Deserialize<List<CocktailsRootDto>>(json);

                if (result != null)
                {
                    cocktailsList.AddRange(result);

                }

            }

            return cocktailsList;

        }

        
        
    }


}
