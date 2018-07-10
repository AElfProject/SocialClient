using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SocialClient.Models;

namespace SocialClient
{
    public interface ISocialClient : IDisposable
    {
        void Auth(AuthContext authContext);
        Task<AccountInfo> GetAccountInfoAsync();
        Task<List<Comment>> GetComments(string postId, int offset = 0, int num = 0);
        Task<List<Post>> GetPosts(string userId, int offset = 0, int num = 0);
        Task<List<string>> GetFollowers(string userId, int offset = 0, int num = 0);
        Task<List<string>> GetFollowing(string userId, int offset = 0, int num = 0);

        Task<List<UserInfo>> GetUsers(IEnumerable<string> ids);
        Task<UserInfo> GetUser(string id);

    }

}