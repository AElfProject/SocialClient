using System.Threading.Tasks;
using Xunit;

namespace SocialClient.Tests
{
    public abstract class ClientTests<T> where T:ISocialClient,new()
    {

        protected ISocialClient _client;
        
        public ClientTests()
        {
            _client = new TwitterSocialClient();
            _client.Auth(GetAuthContext());
        }
        
        protected abstract AuthContext GetAuthContext();
        
        [Fact]
        public async Task GetSelf()
        {
            
        }
    }

    public class TwitterClientTests : ClientTests<TwitterSocialClient>
    {
        protected override AuthContext GetAuthContext()
        {
            return new AuthContext()
            {

            };
        }
    }
    
}