using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Facebook.ApiClient.ApiEngine;
using Facebook.ApiClient.Exceptions;
using SocialClient.Models;

namespace SocialClient
{
    public class FacebookSocialClient: ISocialClient
    {
        private Facebook.ApiClient.ApiEngine.ApiClient _client;
        
        public void Dispose()
        {
        }

        
        private async Task<T> CallAsync<T>(Func<Task<T>> func)
        {
            try
            {
                return await func();
            }
            catch (FacebookClientException ex)
            {
                throw new SocialClientRequestException(SocialClientRequestExceptionTypes.Unknow,ex.InnerException);
            }
        }
        
        public void Auth(AuthContext authContext)
        {
            _client = new ApiClient(authContext.AppKey, authContext.AppSecret, authContext.AccessToken);
        }

        public async Task<AccountInfo> GetAccountInfoAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Comment>> GetComments(string postId, int offset = 0, int num = 0)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Post>> GetPosts(string userId, int offset = 0, int num = 0)
        {
            throw new NotImplementedException();
        }

        public async Task<List<string>> GetFollowers(string userId, int offset = 0, int num = 0)
        {
            throw new NotImplementedException();
        }

        public async Task<List<string>> GetFollowing(string userId, int offset = 0, int num = 0)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserInfo>> GetUsers(IEnumerable<string> ids)
        {
            throw new NotImplementedException();
        }

        public async Task<UserInfo> GetUser(string id)
        {
            throw new NotImplementedException();
        }
    }
}