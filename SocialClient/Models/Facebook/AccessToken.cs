using Newtonsoft.Json;
using RestSharp.Deserializers;

namespace SocialClient.Models.Facebook
{
    public class AccessToken
    {
        [DeserializeAs(Name = "expires_at")]
        [JsonProperty(PropertyName = "expires_at", ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                      DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore,
                      ObjectCreationHandling = ObjectCreationHandling.Auto)]
        public int ExpiresAt { get; set; }

        [DeserializeAs(Name = "is_valid")]
        [JsonProperty(PropertyName = "is_valid", ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                      DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore,
                      ObjectCreationHandling = ObjectCreationHandling.Auto)]
        public string isValid { get; set; }
    }
}
