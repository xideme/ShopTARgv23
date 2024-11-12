using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShopTARgv23.Core.Dto.WeatherDtos
{
    public class AccuLocationWeatherResultDto
    {
        public string CityName { get; set; }

        public string RegionId { get; set; }

        public string CityCode { get; set; }

        public int Rank { get; set; }

        public string EffectiveDate { get; set; }

        public long  EffectiveDateEpochDate { get; set; }

        public long EndEpochDate { get; set; }
        public Uri MobileLink { get; set; }

        public long DailyForecastsEpochDate { get; set; }

        public long TempMinValue { get; set; }

        public long TempMinUnit { get; set; }


        public long TempMinUnitType { get; set; }

        public long TempMaxValue { get; set; }

        public long TempMaxUnit { get; set; }

        public long TempMaxUnitType { get; set; }

        public long DayIcon { get; set; }

        public string DayIconPhrase { get; set; }

        public long NightIcon { get; set; }

        public string NightIconPhrase { get; set; }

        public bool DayHasPrecipitation { get; set; }

        public string DayPrecipitationType { get; set; }

        public string DayPrecipitationIntensity { get; set; }

        public bool NightHasPrecipitation { get; set; }

        public string NightPrecipitationType { get; set; }

        public string NightPrecipitationIntensity { get; set; }

        public string[] Sources { get; set; }

        public Uri DailyForecastsMobileLink { get; set; }

        public Uri DailyForecastsLink { get; set; }

        public Uri Link { get; set; }

        public DateTimeOffset DailyForecastsDate { get; set; }

        public string Text { get; set; }

        public DateTimeOffset EndDate { get; set; }

        public int Severity { get; set; }
        public string Category { get; set; }


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
