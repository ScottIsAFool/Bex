using System.Collections.Generic;
using Newtonsoft.Json;

namespace Bex.Model.Responses
{
    public class SummariesResponse
    {
        [JsonProperty("summaries")]
        public List<Summary> Summaries { get; set; }

        [JsonProperty("nextPage")]
        public string NextPage { get; set; }

        [JsonProperty("itemCount")]
        public int ItemCount { get; set; }
    }
}
