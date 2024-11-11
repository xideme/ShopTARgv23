using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShopTARgv23.Core.Dto.WeatherDtos
{
    public class AccuWeatherRootDto
        {
        
            public Headline Headline { get; set; }

            public List<DailyForecast> DailyForecasts { get; set; }
        }

        public partial class DailyForecast
        {
            [JsonPropertyName("Date")]
            public DateTimeOffset Date { get; set; }

            [JsonPropertyName("EpochDate")]
            public long EpochDate { get; set; }

            [JsonPropertyName("Temperature")]
            public Temperature Temperature { get; set; }

            [JsonPropertyName("Day")]
            public Day Day { get; set; }

            [JsonPropertyName("Night")]
            public Night Night { get; set; }

            [JsonPropertyName("Sources")]
            public string[] Sources { get; set; }

            [JsonPropertyName("MobileLink")]
            public Uri MobileLink { get; set; }

            [JsonPropertyName("Link")]
            public Uri Link { get; set; }
        }

        public partial class Day
        {
            [JsonPropertyName("Icon")]
            public long Icon { get; set; }

            [JsonPropertyName("IconPhrase")]
            public string IconPhrase { get; set; }

            [JsonPropertyName("HasPrecipitation")]
            public bool HasPrecipitation { get; set; }

            [JsonPropertyName("PrecipitationType")]
            public string PrecipitationType { get; set; }

            [JsonPropertyName("PrecipitationIntensity")]
            public string PrecipitationIntensity { get; set; }
        }

        public partial class Night
        {
            [JsonPropertyName("Icon")]
            public long Icon { get; set; }

            [JsonPropertyName("IconPhrase")]
            public string IconPhrase { get; set; }

            [JsonPropertyName("HasPrecipitation")]
            public bool HasPrecipitation { get; set; }

            [JsonPropertyName("PrecipitationType")]
            public string PrecipitationType { get; set; }

            [JsonPropertyName("PrecipitationIntensity")]
            public string PrecipitationIntensity { get; set; }
    }

        public partial class Temperature
        {
            [JsonPropertyName("Minimum")]
            public Imum Minimum { get; set; }

            [JsonPropertyName("Maximum")]
            public Imum Maximum { get; set; }
        }

        public partial class Imum
        {
            [JsonPropertyName("Value")]
            public long Value { get; set; }

            [JsonPropertyName("Unit")]
            public long Unit { get; set; }

            [JsonPropertyName("UnitType")]
            public long UnitType { get; set; }
        }

        public partial class Headline
        {
            [JsonPropertyName("EffectiveDate")]
            public string EffectiveDate { get; set; }

            [JsonPropertyName("EffectiveEpochDate")]
            public long EffectiveEpochDate { get; set; }

            [JsonPropertyName("Severity")]
            public int Severity { get; set; }

            [JsonPropertyName("Text")]
            public string Text { get; set; }

            [JsonPropertyName("Category")]
            public string Category { get; set; }

            [JsonPropertyName("EndDate")]
            public DateTimeOffset EndDate { get; set; }

            [JsonPropertyName("EndEpochDate")]
            public long EndEpochDate { get; set; }

            [JsonPropertyName("MobileLink")]
            public Uri MobileLink { get; set; }

            [JsonPropertyName("Link")]
            public Uri Link { get; set; }
        }
    }

