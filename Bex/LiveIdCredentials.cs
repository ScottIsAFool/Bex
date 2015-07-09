using Newtonsoft.Json;

namespace Bex
{
    public class LiveIdCredentials
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("expires_in")]
        public long ExpiresIn { get; set; }
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
        [JsonProperty("user_id")]
        public string UserId { get; set; }
    }
}
