using System;
using Newtonsoft.Json;

namespace Bex.Model
{
    public class Summary
    {
        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("startTime")]
        public DateTime? StartTime { get; set; }

        [JsonProperty("endTime")]
        public DateTime? EndTime { get; set; }

        [JsonProperty("period")]
        public string Period { get; set; }

        [JsonProperty("duration")]
        public string Duration { get; set; }

        [JsonProperty("stepsTaken")]
        public int StepsTaken { get; set; }

        [JsonProperty("caloriesBurnedSummary")]
        public CaloriesBurnedSummary CaloriesBurnedSummary { get; set; }

        [JsonProperty("heartRateSummary")]
        public HeartRateSummary HeartRateSummary { get; set; }

        [JsonProperty("distanceSummary")]
        public DistanceSummary DistanceSummary { get; set; }

        [JsonProperty("activeHours")]
        public int ActiveHours { get; set; }
    }
}