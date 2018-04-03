using System;
using System.Threading.Tasks;
using SocialClient.Models;

namespace SocialClient
{
    public interface ISocialClient : IDisposable
    {
        void Auth(AuthContext authContext);
        Task<AccountInfo> GetAccountInfoAsync();
    }
}