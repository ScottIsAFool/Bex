using System.Collections.Generic;
using Newtonsoft.Json;

namespace Bex.Model.Responses
{
    internal class DevicesResponse
    {
        [JsonProperty("deviceProfiles")]
        public IEnumerable<Device> Devices { get; set; }
    }
}
