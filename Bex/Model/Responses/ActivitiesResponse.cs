using System.Collections.Generic;
using Newtonsoft.Json;

namespace Bex.Model.Responses
{
    public class ActivitiesResponse
    {
        [JsonProperty("bikeActivities")]
        public List<BikeActivity> BikeActivities { get; set; }

        [JsonProperty("freePlayActivities")]
        public List<FreePlayActivity> FreePlayActivities { get; set; }

        [JsonProperty("golfActivities")]
        public List<GolfActivity> GolfActivities { get; set; }

        [JsonProperty("guidedWorkoutActivities")]
        public List<GuidedWorkoutActivity> GuidedWorkoutActivities { get; set; }

        [JsonProperty("runActivities")]
        public List<RunActivity> RunActivities { get; set; }

        [JsonProperty("sleepActivities")]
        public List<SleepActivity> SleepActivities { get; set; }

        [JsonProperty("nextPage")]
        public string NextPage { get; set; }

        [JsonProperty("itemCount")]
        public int ItemCount { get; set; }
    }
}
