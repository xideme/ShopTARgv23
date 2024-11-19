using ShopTARgv23.Core.Dto.CocktailDto;
using ShopTARgv23.Core.Dto.FreeToPlayRootDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARgv23.Core.ServiceInterface
{
    public interface ICocktailsServices
    {
        Task<CocktailResultDto> GetCocktails(CocktailResultDto dto);
    }
}
