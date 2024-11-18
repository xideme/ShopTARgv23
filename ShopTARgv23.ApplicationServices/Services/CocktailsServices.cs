using ShopTARgv23.Core.Dto.CocktailsDto;
using ShopTARgv23.Core.Dto.FreeToPlayRootDto;
using ShopTARgv23.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARgv23.ApplicationServices.Services
{
    public class CocktailsServices : ICocktailsServices
    {

        public async Task<List<CocktailsResultDto>> CocktailsResult(CocktailsResultDto dto)
        {
            string url = $"www.thecocktaildb.com/api/json/v1/1/search.php?s={dto.strDrink}";
        }

        
    }

}
