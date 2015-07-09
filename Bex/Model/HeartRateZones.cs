using Newtonsoft.Json;

namespace Bex.Model
{
    public class HeartRateZones
    {
        [JsonProperty("underAerobic")]
        public int UnderAerobic { get; set; }

        [JsonProperty("aerobic")]
        public int Aerobic { get; set; }

        [JsonProperty("anaerobic")]
        public int Anaerobic { get; set; }

        [JsonProperty("fitnessZone")]
        public int FitnessZone { get; set; }

        [JsonProperty("healthyHeart")]
        public int HealthyHeart { get; set; }

        [JsonProperty("redline")]
        public int Redline { get; set; }

        [JsonProperty("overRedline")]
        public int OverRedline { get; set; }
    }
}