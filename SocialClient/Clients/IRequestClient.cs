using System;
using System.Threading.Tasks;
using RestSharp;

namespace SocialClient
{
    public interface IRequestClient
    {
        Task<IRestResponse<T>> ExecuteTaskAsync<T>(RestRequest request) where T : class, new();
    }
}
