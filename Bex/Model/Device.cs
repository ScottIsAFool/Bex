using System;
using Newtonsoft.Json;

namespace Bex.Model
{
    public class Device
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("lastSuccessfulSync")]
        public DateTime? LastSuccessfulSync { get; set; }

        [JsonProperty("deviceFamily")]
        public string DeviceFamily { get; set; }
    }
}
