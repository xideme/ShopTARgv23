using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARgv23.Core.Dto.WeatherDtos
{
    public class AccuLocationWeatherResultDto
    {
        public string CityName { get; set; }

        public string RegionId { get; set; }

        public int Rank { get; set; }

        public string EffectiveDate { get; set; }

        public string LocalizedName { get; set; }
        public string EnglishName { get; set; }
        public string PrimaryPostalCode { get; set; }

        public string Country { get; set; }

        public string TimeZone { get; set; }

        public int CountryID { get; set; }

        public int Level { get; set; }

        public double GeoPosition { get; set; }

        public float GmtOffset { get; set; }
        public bool IsDaylightSaving { get; set; }
        public DateTime? NextOffsetChange { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Elevation { get; set; }



    }
}
