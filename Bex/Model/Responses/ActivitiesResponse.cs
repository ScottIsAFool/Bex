using System.Collections.Generic;
using Newtonsoft.Json;

namespace Bex.Model.Responses
{
    public class ActivitiesResponse
    {
        [JsonProperty("bikeActivities")]
        public IEnumerable<BikeActivity> BikeActivities { get; set; }

        [JsonProperty("freePlayActivities")]
        public IEnumerable<FreePlayActivity> FreePlayActivities { get; set; }

        [JsonProperty("golfActivities")]
        public IEnumerable<GolfActivity> GolfActivities { get; set; }

        [JsonProperty("guidedWorkoutActivities")]
        public IEnumerable<GuidedWorkoutActivity> GuidedWorkoutActivities { get; set; }

        [JsonProperty("runActivities")]
        public IEnumerable<RunActivity> RunActivities { get; set; }

        [JsonProperty("sleepActivities")]
        public IEnumerable<SleepActivity> SleepActivities { get; set; }

        [JsonProperty("nextPage")]
        public string NextPage { get; set; }

        [JsonProperty("itemCount")]
        public int ItemCount { get; set; }
    }
}
