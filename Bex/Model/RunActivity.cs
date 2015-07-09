using Newtonsoft.Json;

namespace Bex.Model
{
    public class RunActivity : ActivityBase
    {
        [JsonProperty("performanceSummary")]
        public PerformanceSummary PerformanceSummary { get; set; }

        [JsonProperty("distanceSummary")]
        public DistanceSummary DistanceSummary { get; set; }

        [JsonProperty("pausedDuration")]
        public string PausedDuration { get; set; }

        [JsonProperty("splitDistance")]
        public int SplitDistance { get; set; }

        [JsonProperty("mapPoints")]
        public MapPoint[] MapPoints { get; set; }
    }
}