using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Bex.Model
{
    public class ActivitySegment
    {
        [JsonProperty("distanceSummary")]
        public DistanceSummary DistanceSummary { get; set; }

        [JsonProperty("rounds")]
        public List<Round> Rounds { get; set; }

        [JsonProperty("pausedDuration")]
        public string PausedDuration { get; set; }

        [JsonProperty("heartRateZones")]
        public HeartRateZones HeartRateZones { get; set; }

        [JsonProperty("splitDistance")]
        public int SplitDistance { get; set; }

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