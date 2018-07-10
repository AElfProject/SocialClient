using System.Threading.Tasks;
using SocialClient.Clients.Facebook;
using Xunit;

namespace SocialClient.Tests
{
    public abstract class ClientTests<T> where T:ISocialClient,new()
    {

        protected ISocialClient _client;
        
        public ClientTests()
        {
            _client = new T();
            _client.Auth(GetAuthContext());
        }
        
        protected abstract AuthContext GetAuthContext();
        
        [Fact]
        public async Task GetSelf()
        {
            
        }
    }

    public class FacebookClientTests : ClientTests<FacebookSocialClient>
    {
        protected override AuthContext GetAuthContext()
        {
            return new AuthContext()
            {

            };
        }
    }
    
}