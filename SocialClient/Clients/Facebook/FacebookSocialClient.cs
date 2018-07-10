using System.Collections.Generic;
using System.Threading.Tasks;
using SocialClient.Models;

namespace SocialClient.Clients.Facebook
{
    public class FacebookSocialClient: ISocialClient
    {
        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public void Auth(AuthContext authContext)
        {
            throw new System.NotImplementedException();
        }

        public async Task<AccountInfo> GetAccountInfoAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Comment>> GetComments(string postId, int offset = 0, int num = 0)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Post>> GetPosts(string userId, int offset = 0, int num = 0)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<string>> GetFollowers(string userId, int offset = 0, int num = 0)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<string>> GetFollowing(string userId, int offset = 0, int num = 0)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<UserInfo>> GetUsers(IEnumerable<string> ids)
        {
            throw new System.NotImplementedException();
        }

        public async Task<UserInfo> GetUser(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}