using Newtonsoft.Json;

namespace Bex.Model
{
    public class MapPoint
    {
        [JsonProperty("secondsSinceStart")]
        public int SecondsSinceStart { get; set; }

        [JsonProperty("mapPointType")]
        public string MapPointType { get; set; }

        [JsonProperty("ordinal")]
        public int Ordinal { get; set; }

        [JsonProperty("actualDistance")]
        public int ActualDistance { get; set; }

        [JsonProperty("totalDistance")]
        public int TotalDistance { get; set; }

        [JsonProperty("heartRate")]
        public int HeartRate { get; set; }

        [JsonProperty("pace")]
        public int Pace { get; set; }

        [JsonProperty("scaledPace")]
        public int ScaledPace { get; set; }

        [JsonProperty("speed")]
        public int Speed { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("isPaused")]
        public bool IsPaused { get; set; }

        [JsonProperty("isResume")]
        public bool IsResume { get; set; }
    }
}