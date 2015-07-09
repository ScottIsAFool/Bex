using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Bex.Model
{
    public abstract class ActivityBase
    {
        [JsonProperty("activityType")]
        public string ActivityType { get; set; }

        [JsonProperty("activitySegments")]
        public List<ActivitySegment> ActivitySegments { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("deviceId")]
        public string DeviceId { get; set; }

        [JsonProperty("startTime")]
        public DateTime? StartTime { get; set; }

        [JsonProperty("endTime")]
        public DateTime? EndTime { get; set; }

        [JsonProperty("dayId")]
        public string DayId { get; set; }

        [JsonProperty("createdTime")]
        public DateTime? CreatedTime { get; set; }

        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("duration")]
        public string Duration { get; set; }

        [JsonProperty("minuteSummaries")]
        public List<MinuteSummary> MinuteSummaries { get; set; }

        [JsonProperty("caloriesBurnedSummary")]
        public CaloriesBurnedSummary CaloriesBurnedSummary { get; set; }

        [JsonProperty("heartRateSummary")]
        public HeartRateSummary HeartRateSummary { get; set; }
    }
}