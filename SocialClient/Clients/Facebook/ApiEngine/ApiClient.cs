using System;
using System.Collections.Generic;
using System.Text;
using SocialClient.Clients.Facebook.Constants;

namespace SocialClient.Clients.Facebook.ApiEngine
{
    public class ApiClient
    {
        /// <summary>
        /// An access token is an opaque string that identifies a user, app, or Page and can be used by the app to make graph API calls.
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Facebook Application Id
        /// </summary>
        public string AppKey { get; set; }

        /// <summary>
        /// Facebook Application secret key
        /// </summary>
        public string AppSecret { get; set; }

        /// <summary>
        /// Facebook api version to use while making api calls
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Local proxy
        /// </summary>
        public string Proxy { get; set;}

        public ApiClient()
        {
            _setApiVersion(Version);
        }

        //public ApiClient(string accessToken, string appKey, string appSecret,  string proxy = null, string version = null)
        //{
        //    _setAccessToken(accessToken);
        //    _setAppKey(appKey);
        //    _setAppSecret(appSecret);

        //    _setLocalProxy(proxy);
        //    _setApiVersion(version);
        //}

        //private void _setAppKey(string appKey)
        //{
        //    this.AppKey = appKey;
        //}

        //private void _setAppSecret(string appSecret)
        //{
        //    this.AppSecret = appSecret;
        //}

        //private void _setAccessToken(string accessToken)
        //{
        //    this.AccessToken = accessToken;
        //}

        //private void _setLocalProxy(string proxy)
        //{
        //    this.Proxy = proxy;
        //}

        private void _setApiVersion(string version)
        {
            Version = string.IsNullOrEmpty(version) ? FacebookApiRequestUrls.GRAPH_REQUEST_VERSION : version;
        }
    }
}
