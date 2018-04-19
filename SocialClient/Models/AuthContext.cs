using Newtonsoft.Json;
using RestSharp.Deserializers;

namespace SocialClient.Models
{
    public class AuthContext
    {
        [DeserializeAs(Name = "access_token")]
        [JsonProperty(PropertyName = "access_token", ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                      DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore,
                      ObjectCreationHandling = ObjectCreationHandling.Auto)]
        public string AccessToken { get; set; }

        [DeserializeAs(Name = "token_type")]
        [JsonProperty(PropertyName = "token_type", ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
              DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore,
              ObjectCreationHandling = ObjectCreationHandling.Auto)]
        public string TokenType { get; set; }
    }
}
