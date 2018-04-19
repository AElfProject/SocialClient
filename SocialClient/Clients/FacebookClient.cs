using System;
using RestSharp;

namespace SocialClient.HttpClient
{
    public class FacebookClient : Request, IClient
    {
        private FacebookClient(Method method, string url, String version){
            this.restClient = new RestClient(GRAPH_REQUEST_BASE_URL);
            this.url = url;
            this.method = method;
        }

        private FacebookClient(Method method, string url): this(method, url, "v2"){
        }

        public static FacebookClient Create(Method method, string url, string version)
        {
            return new FacebookClient(method, url);
        }

        public static FacebookClient Create(Method method, string url){
            return Create(method, url, "v2");
        }

        public Task<IResponse<TEntity>> ExecuteAsync<TEntity>()
        {
            StartTimer();
            var response = await RestClient.ExecuteTaskAsync<TEntity>(RestRequest);
            StopTimer();

            if (response.ErrorException != null)
                throw new SDKException(response.Content, response.ErrorException);

            return new Response<TEntity>(response.Data, response.Headers, GetExceptionsFromResponse(response));
        }
    }
}
