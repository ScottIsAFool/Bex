using Newtonsoft.Json;

namespace Bex.Model
{
    public class GuidedWorkoutActivity : ActivityBase
    {
        [JsonProperty("cyclesPerformed")]
        public int CyclesPerformed { get; set; }

        [JsonProperty("roundsPerformed")]
        public int RoundsPerformed { get; set; }

        [JsonProperty("repetitionsPerformed")]
        public int RepetitionsPerformed { get; set; }

        [JsonProperty("workoutPlanId")]
        public string WorkoutPlanId { get; set; }

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