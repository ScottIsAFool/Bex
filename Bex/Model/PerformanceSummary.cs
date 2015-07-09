using Newtonsoft.Json;

namespace Bex.Model
{
    public class PerformanceSummary
    {
        [JsonProperty("finishHeartRate")]
        public int FinishHeartRate { get; set; }

        [JsonProperty("recoveryHeartRateAt1Minute")]
        public int RecoveryHeartRateAt1Minute { get; set; }

        [JsonProperty("recoveryHeartRateAt2Minutes")]
        public int RecoveryHeartRateAt2Minutes { get; set; }

        [JsonProperty("heartRateZones")]
        public HeartRateZones HeartRateZones { get; set; }
    }
}