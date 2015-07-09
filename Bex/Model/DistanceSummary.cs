using Newtonsoft.Json;

namespace Bex.Model
{
    public class DistanceSummary
    {
        [JsonProperty("period")]
        public string Period { get; set; }

        [JsonProperty("totalDistance")]
        public double TotalDistance { get; set; }

        [JsonProperty("totalDistanceOnFoot")]
        public double TotalDistanceOnFoot { get; set; }

        [JsonProperty("actualDistance")]
        public double ActualDistance { get; set; }

        [JsonProperty("elevationGain")]
        public double ElevationGain { get; set; }

        [JsonProperty("elevationLoss")]
        public double ElevationLoss { get; set; }

        [JsonProperty("maxElevation")]
        public double MaxElevation { get; set; }

        [JsonProperty("minElevation")]
        public double MinElevation { get; set; }

        [JsonProperty("waypointDistance")]
        public double WaypointDistance { get; set; }

        [JsonProperty("speed")]
        public double Speed { get; set; }

        [JsonProperty("pace")]
        public double Pace { get; set; }

        [JsonProperty("overallPace")]
        public double OverallPace { get; set; }
    }
}