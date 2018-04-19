using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using SocialClient.Clients;
using SocialClient.Models.Facebook;

namespace SocialClient
{
    public class FacebookApi
    {
        private string requestBaseUrl;
        private string requestApiVersion;

        private FacebookOAuth facebookOAuth;
        private RequestClient requestClient;

        private static string[] interalAPIs = { "oauth/access_token", "debug_token" };

        public FacebookApi(string apiBaseUrl, FacebookOAuth facebookOAuth) : this(apiBaseUrl, facebookOAuth, "v2.12")
        {
        }

        public FacebookApi(string apiBaseUrl, FacebookOAuth facebookOAuth, string version)
        {
            this.requestBaseUrl = apiBaseUrl;
            this.requestApiVersion = version;
            this.facebookOAuth = facebookOAuth;
            this.requestClient = new RequestClient(this.requestClient + this.requestApiVersion);
        }

        /// <summary>
        /// Request Facebook API (Get method)
        /// </summary>
        /// <returns>Response.</returns>
        /// <param name="resource">Resource.</param>
        /// <param name="parameters">Request parameters.</param>
        /// <typeparam name="T">Response Entity.</typeparam>
        public async Task<IRestResponse<T>> GetAsync<T>(string resource, Dictionary<string, object> parameters)
        {
            RestRequest request = new RestRequest(resource, Method.GET);
            await AttachAccessToken(request);
            foreach (KeyValuePair<string, object> entry in parameters)
            {
                request.AddParameter(entry.Key, entry.Value);
            }
            return await requestClient.ExecuteTaskAsync<T>(request);
        }

        /// <summary>
        /// Request Facebook API (Post method)
        /// </summary>
        /// <returns></returns>
        /// <param name="resource">Resource.</param>
        /// <param name="parameters">Request parameters.</param>
        /// <typeparam name="T">Response Entity.</typeparam>
        public async Task<IRestResponse<T>> PostAsync<T>(string resource, Dictionary<string, object> parameters)
        {
            RestRequest request = new RestRequest(resource, Method.POST);
            await AttachAccessToken(request);
            foreach (KeyValuePair<string, object> entry in parameters)
            {
                request.AddParameter(entry.Key, entry.Value);
            }
            return await requestClient.ExecuteTaskAsync<T>(request);
        }

        private async Task AttachAccessToken(RestRequest request)
        {
            string accessToken = await GetValidAccessToken(request.Resource);
            if (!string.IsNullOrEmpty(accessToken))
                request.AddParameter("access_token", accessToken);
        }

        private async Task<string> GetValidAccessToken(string resource)
        {
            if (!interalAPIs.Contains(resource.ToLower())
                && !string.IsNullOrEmpty(facebookOAuth.AppKey)
                && !string.IsNullOrEmpty(facebookOAuth.AppSecret)
                && facebookOAuth.ExpireAt < DateTime.UtcNow.Second)
            {
                await RefreshToken();
            }
            return facebookOAuth.AccessToken;
        }

        private async Task<string> RefreshToken()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("client_id", facebookOAuth.AppKey);
            parameters.Add("client_secret", facebookOAuth.AppSecret);
            if (string.IsNullOrEmpty(facebookOAuth.GrantType))
            {
                parameters.Add("grant_type", facebookOAuth.GrantType);
                if (facebookOAuth.GrantType == "fb_exchange_token")
                {
                    parameters.Add("fb_exchange_token", facebookOAuth.ExchangeToken ?? facebookOAuth.AccessToken);
                }
            }
            IRestResponse<FacebookAuthContext> response = await PostAsync<FacebookAuthContext>("oauth/access_token", parameters);
            facebookOAuth.AccessToken = response.Data.AccessToken;
            int expireAt = await GetAccessTokenExpireAt();
            facebookOAuth.ExpireAt = expireAt > 0 ? expireAt : DateTime.UtcNow.AddDays(1).Second; // Default 1 Day
            return facebookOAuth.AccessToken;
        }

        private async Task<int> GetAccessTokenExpireAt()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("input_token", facebookOAuth.AccessToken);
            IRestResponse<AccessToken> response = await GetAsync<AccessToken>("debug_token", parameters);
            return response.Data.ExpiresAt;
        }
    }
}
