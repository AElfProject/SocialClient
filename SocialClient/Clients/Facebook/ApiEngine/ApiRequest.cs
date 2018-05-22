using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;
using RestSharp;
using SocialClient.Clients.Facebook.Constants;
using SocialClient.Clients.Facebook.Exceptions;
using SocialClient.Clients.Facebook.Interfaces;

namespace SocialClient.Clients.Facebook.ApiEngine
{
    public class ApiRequest
    {
        private Stopwatch _apiTimer;

        /// <summary>
        /// Instance of RestClient 
        /// </summary>
        protected IRestClient RestClient { get; private set; }

        /// <summary>
        /// Instance of RestRequest
        /// </summary>
        protected IRestRequest RestRequest { get; private set; }

        /// <summary>
        /// <see cref="ApiEngine.ApiClient"/> to use to execute API request
        /// </summary>
        public ApiClient Client { get; protected set; }

        /// <summary>
        /// API request uri
        /// </summary>
        public string Resource { get; protected set; }

        /// <summary>
        /// Initialize instance of <see cref="ApiRequest"/>
        /// </summary>
        protected ApiRequest(string resource, ApiClient client)
        {
            Resource = resource;
            Client = client;

            RestClient = new RestClient(FacebookApiRequestUrls.GRAPH_REQUEST_BASE_URL);
            RestRequest = new RestRequest(resource, Method.GET);
            if(!string.IsNullOrEmpty(Client.Proxy))
                RestClient.Proxy = new WebProxy(Client.Proxy);

            SetFacebookRequestParameters();
        }

        private void SetFacebookRequestParameters()
        {
            RestRequest.AddParameter(FacebookApiRequestParameters.API_VERSION, Client.Version, ParameterType.UrlSegment);
            RestRequest.AddParameter(FacebookApiRequestParameters.ACCESS_TOKEN, Client.AccessToken, ParameterType.QueryString);
        }

        public static IApiRequest Create(string resource, ApiClient client)
        {
            return new PagedRequest(resource, client);
        }

        public void AddUrlSegment(string name, string value)
        {
            RestRequest.AddUrlSegment(name, value);
        }

        public void AddHttpHeader(string name, string value)
        {
            RestRequest.AddHeader(name, value);
        }

        public void AddCookie(string name, string value)
        {
            RestRequest.AddCookie(name, value);
        }

        /// <summary>
        /// Check if there is any api exception in received resonse. If yes then return list of api exceptions
        /// </summary>
        /// <param name="response">Received api response</param>
        /// <returns>List of api exceptions from received response</returns>
        protected static IEnumerable<FacebookOAuthException> GetExceptionsFromResponse(IRestResponse response)
        {
            IList<FacebookOAuthException> exceptions = new List<FacebookOAuthException>();

            if (response.StatusCode != HttpStatusCode.BadRequest) return exceptions;

            var responseHeaders =
                response.Headers.ToDictionary(e => e.Name);

            var parsedException = JObject.Parse(response.Content);
            var exceptionCode = parsedException["error"]?["code"] != null
                ? int.Parse(parsedException["error"]["code"].ToString(), CultureInfo.CurrentCulture)
                : 200;


            exceptions.Add(new FacebookOAuthException(exceptionCode, parsedException["error"]?["message"].ToString())
            {
                FBTraceId =
                    responseHeaders.ContainsKey(FacebookApiResponseHeaders.X_FB_TRACE_ID)
                        ? responseHeaders[FacebookApiResponseHeaders.X_FB_TRACE_ID].Value.ToString()
                        : string.Empty,
                FBRev =
                    responseHeaders.ContainsKey(FacebookApiResponseHeaders.X_FB_REV)
                        ? responseHeaders[FacebookApiResponseHeaders.X_FB_REV].Value.ToString()
                        : string.Empty,
                FBDebug =
                    responseHeaders.ContainsKey(FacebookApiResponseHeaders.X_FB_DEBUG)
                        ? responseHeaders[FacebookApiResponseHeaders.X_FB_DEBUG].Value.ToString()
                        : string.Empty,
                RawExceptionString = response.Content,
                ErrorUserMessage = parsedException["error"]?["error_user_message"]?.ToString(),
                ErrorUserTitle = parsedException["error"]?["error_user_title"]?.ToString(),
                SubCode = parsedException["error"]?["subcode"] != null
                    ? int.Parse(parsedException["error"]["subcode"].ToString())
                    : 0
            });

            return exceptions;
        }


        /// <summary>
        /// Initialize &amp; start <see cref="_apiTimer"/>
        /// </summary>
        protected void StartTimer()
        {
            if (_apiTimer == null)
                _apiTimer = new Stopwatch();

            if (_apiTimer.IsRunning)
            {
                _apiTimer.Stop();
                _apiTimer.Reset();
            }

            _apiTimer.Start();
        }

        /// <summary>
        /// Stop <see cref="_apiTimer"/>
        /// </summary>
        protected void StopTimer()
        {
            _apiTimer.Stop();
        }

        public TimeSpan GetElapsedTime()
        {
            return _apiTimer.Elapsed;
        }

    }
}
