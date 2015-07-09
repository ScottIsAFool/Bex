using System;
using Newtonsoft.Json;

namespace Bex.Model
{
    public class Profile
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("middleName")]
        public string MiddleName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("birthdate")]
        public DateTime? Birthdate { get; set; }

        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("weight")]
        public int Weight { get; set; }

        [JsonProperty("preferredLocale")]
        public string PreferredLocale { get; set; }

        [JsonProperty("lastUpdateTime")]
        public DateTime? LastUpdateTime { get; set; }
    }

}
