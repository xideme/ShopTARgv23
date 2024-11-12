using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARgv23.Core.Dto.FreeToPlayRootDto
{
    public class FreeToPlayResultDto
    {

        public long Id { get; set; }
        public string Title { get; set; }
        public Uri Thumbnail { get; set; }
        public string ShortDescription { get; set; }
        public Uri GameUrl { get; set; }
        public string Genre { get; set; }
        public string Platform { get; set; }
        public string Publisher { get; set; }
        public string Developer { get; set; }
        public DateTimeOffset ReleaseDate { get; set; }
        public Uri FreetogameProfileUrl { get; set; }
    }
}
