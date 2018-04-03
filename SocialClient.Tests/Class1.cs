using System;
using LinqToTwitter;
using Xunit;

namespace SocialClient.Tests
{
    
    public class Class1
    {
        [Fact]
        public void Test()
        {
            var auth = new SingleUserAuthorizer
            {
                CredentialStore = new SingleUserInMemoryCredentialStore
                {
                    ConsumerKey = Environment.GetEnvironmentVariable(OAuthKeys.TwitterConsumerKey),
                    ConsumerSecret = Environment.GetEnvironmentVariable(OAuthKeys.TwitterConsumerSecret),
                    AccessToken = Environment.GetEnvironmentVariable(OAuthKeys.TwitterAccessToken),
                    AccessTokenSecret = Environment.GetEnvironmentVariable(OAuthKeys.TwitterAccessTokenSecret)
                }
            };
            var context = new TwitterContext(auth);
        }
    }
}