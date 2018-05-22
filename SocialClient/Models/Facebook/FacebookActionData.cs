using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace SocialClient.Models.Facebook
{
   
    public class FacebookActionData : User
    {
        [JsonProperty("created_time")]
        public DateTime CreatedTime { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("from")]
        public User From { get; set; }
    }

    public class User
    {
        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("name")] public string Name { get; set; }
    }
}
