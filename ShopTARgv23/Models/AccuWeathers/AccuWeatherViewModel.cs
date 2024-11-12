namespace ShopTARgv23.Models.AccuWeathers
{
    public class AccuWeatherViewModel
    {

        public string CityName { get; set; }
        public string EffectiveDate { get; set; }
        public int Severity { get; set; }

        public string Text {  get; set; }
        public string Category { get; set; }

        public long EffectiveDateEpochDate { get; set; }

        public DateTimeOffset EndDate { get; set; }

        public long EndEpochDate { get; set; }

        public DateTimeOffset DailyForecastsDate { get; set; }
        public long DailyForecastsEpochDate { get; set; }


        public double TemMinValue { get; set; }

        public double TemMinUnit { get; set; }

        public double TemMinUnitType { get; set; }

        public double TemMaxValue { get; set; }

        public long TempMaxUnit { get; set; }

        public long TempMaxUnitType { get; set; }

        public long TempMinValue { get; set; }

        public long TempMinUnit { get; set; }

        public long TempMinUnitType { get; set; }

        public long TempMaxValue { get; set; }

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

        public Uri MobileLink { get; set; }

        public Uri Link { get; set; }



    }
}
