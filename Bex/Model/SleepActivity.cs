using Newtonsoft.Json;

namespace Bex.Model
{
    public class SleepActivity : ActivityBase
    {
        [JsonProperty("awakeDuration")]
        public string AwakeDuration { get; set; }

        [JsonProperty("sleepDuration")]
        public string SleepDuration { get; set; }

        [JsonProperty("numberOfWakeups")]
        public int NumberOfWakeups { get; set; }

        [JsonProperty("fallAsleepDuration")]
        public string FallAsleepDuration { get; set; }

        [JsonProperty("sleepEfficiencyPercentage")]
        public int SleepEfficiencyPercentage { get; set; }

        [JsonProperty("totalRestlessSleepDuration")]
        public string TotalRestlessSleepDuration { get; set; }

        [JsonProperty("totalRestfulSleepDuration")]
        public string TotalRestfulSleepDuration { get; set; }

        [JsonProperty("restingHeartRate")]
        public int RestingHeartRate { get; set; }

        [JsonProperty("fallAsleepTime")]
        public string FallAsleepTime { get; set; }

        [JsonProperty("wakeupTime")]
        public string WakeupTime { get; set; }
    }
}