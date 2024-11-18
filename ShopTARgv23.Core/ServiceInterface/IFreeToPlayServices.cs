using ShopTARgv23.Core.Dto.ChuckNorrisRootDto;
using ShopTARgv23.Core.Dto.FreeToPlayRootDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARgv23.Core.ServiceInterface
{
    public interface IFreeToPlayServices
    {
        Task<List<FreeToPlayRootDto>> FreeToPlayResult();
    }
}
