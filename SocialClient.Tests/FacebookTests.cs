using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using SocialClient.Clients;
using SocialClient.Clients.Facebook;
using SocialClient.Models.Facebook;
using Xunit;

namespace SocialClient.Tests
{
    public class FacebookTests
    {
        [Fact]
        public async Task TestMeAsync()
        {
            FacebookOAuth facebookOAuth = new FacebookOAuth()
            {
                AccessToken = Environment.GetEnvironmentVariable("FACEBOOK_ACCESS_TOKEN"),
            };
            FacebookGraphApi facebookGraphApi = new FacebookGraphApi(facebookOAuth);
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            IRestResponse<FacebookAuthContext> likes = await facebookGraphApi.GetAsync<FacebookAuthContext>("me", parameters);
        }
    }
}
