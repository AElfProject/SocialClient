using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinqToTwitter;
using SocialClient.Models;

namespace SocialClient
{
    public class TwitterSocialClient : ISocialClient
    {
        private TwitterContext _context;

        public void Auth(AuthContext authContext)
        {
            var auth = new SingleUserAuthorizer
            {
                CredentialStore = new SingleUserInMemoryCredentialStore
                {
                    ConsumerKey = authContext.AppKey,
                    ConsumerSecret = authContext.AppSecret,
                    AccessToken = authContext.AccessToken,
                    AccessTokenSecret = authContext.AccessTokenSecret
                }
            };
            _context = new TwitterContext(auth);
        }


        private async Task<T> CallAsync<T>(Func<Task<T>> func)
        {
            try
            {
                return await func();
            }
            catch (TwitterQueryException tqe)
            {
                throw new SocialClientRequestException(SocialClientRequestExceptionTypes.Unknow,tqe.InnerException);
            }
        }

        public async Task<AccountInfo> GetAccountInfoAsync()
        {
            return await CallAsync(async () =>
            {
                var verifyResponse =
                    await
                        (from acct in _context.Account
                            where acct.Type == AccountType.VerifyCredentials
                            select acct)
                        .SingleOrDefaultAsync();

                var user = verifyResponse.User;

                
                return new AccountInfo()
                {
                    Email = user.Email,
                    Followers = user.FollowersCount,
                    Following = user.FriendsCount,
                };
            });
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

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}