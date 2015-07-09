using System.Collections.Generic;
using Newtonsoft.Json;

namespace Bex.Model
{
    public class GolfActivity : ActivityBase
    {
        [JsonProperty("totalStepCount")]
        public int TotalStepCount { get; set; }

        [JsonProperty("totalDistanceWalked")]
        public int TotalDistanceWalked { get; set; }

        [JsonProperty("parOrBetterCount")]
        public int ParOrBetterCount { get; set; }

        [JsonProperty("longestDriveDistance")]
        public int LongestDriveDistance { get; set; }

        [JsonProperty("longestStrokeDistance")]
        public int LongestStrokeDistance { get; set; }

        [JsonProperty("childActivities")]
        public List<ChildActivity> ChildActivities { get; set; }
    }
}