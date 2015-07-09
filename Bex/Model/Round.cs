using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Bex.Model
{
    public class Round
    {
        [JsonProperty("exercises")]
        public List<Exercise> Exercises { get; set; }

        [JsonProperty("roundOrdinal")]
        public int RoundOrdinal { get; set; }

        [JsonProperty("segmentId")]
        public int SegmentId { get; set; }

        [JsonProperty("startTime")]
        public DateTime? StartTime { get; set; }

        [JsonProperty("endTime")]
        public DateTime? EndTime { get; set; }

        [JsonProperty("duration")]
        public string Duration { get; set; }

        [JsonProperty("heartRateSummary")]
        public HeartRateSummary HeartRateSummary { get; set; }

        [JsonProperty("caloriesBurnedSummary")]
        public CaloriesBurnedSummary CaloriesBurnedSummary { get; set; }

        [JsonProperty("segmentType")]
        public string SegmentType { get; set; }
    }
}