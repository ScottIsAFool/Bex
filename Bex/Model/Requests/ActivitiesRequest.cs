using System;
using System.Collections.Generic;
using Bex.Extensions;

namespace Bex.Model.Requests
{
    public class ActivitiesRequest
    {
        public List<string> ActivityIds { get; set; }
        public List<string> ActivityTypes { get; set; }
        public List<ActivityFields> ActivityFieldsToInclude { get; set; }
        public List<string> DeviceIds { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public SplitDistanceType? SplitDistanceType { get; set; }
        public int? MaxItemsReturned { get; set; }

        internal Dictionary<string, string> ToDictionary()
        {
            var postData = new Dictionary<string, string>();

            if (!ActivityIds.IsNullOrEmpty())
            {
                postData.Add("activityIds", ActivityIds.ToCommaSeparatedString());
            }

            if (!ActivityTypes.IsNullOrEmpty())
            {
                postData.Add("activityTypes", ActivityTypes.ToCommaSeparatedString());
            }

            if (!ActivityFieldsToInclude.IsNullOrEmpty())
            {
                postData.Add("activityIncludes", ActivityFieldsToInclude.ToCommaSeparatedString());
            }

            if (!DeviceIds.IsNullOrEmpty())
            {
                postData.Add("deviceIds", DeviceIds.ToCommaSeparatedString());
            }

            if (StartTime.HasValue)
            {
                postData.Add("startTime", StartTime.Value.ToString("O"));
            }

            if (EndTime.HasValue)
            {
                postData.Add("endTime", EndTime.Value.ToString("O"));
            }

            if (SplitDistanceType.HasValue)
            {
                postData.Add("splitDistanceType", SplitDistanceType.Value.ToString());
            }

            if (MaxItemsReturned.HasValue)
            {
                postData.Add("maxPageSize", MaxItemsReturned.Value.ToString());
            }

            return postData;
        } 
    }
}
