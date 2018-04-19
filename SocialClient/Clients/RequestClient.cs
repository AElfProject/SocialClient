using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using RestSharp;

namespace SocialClient
{
    public class RequestClient
    {
        private RestClient restClient;
        private Stopwatch _apiTimer;

        public RequestClient(string host)
        {
            restClient = new RestClient(host);
        }

        public async Task<IRestResponse<T>> ExecuteTaskAsync<T>(RestRequest request)
        {
            StartTimer();
            IRestResponse<T> response = await restClient.ExecuteTaskAsync<T>(request);
            StopTimer();

            if (response.ErrorException != null)
            {
                throw new SocialClientException(SocialClientExceptionTypes.Unknow, response.Content, response.ErrorException);
            }

            return response;
        }

        /// <summary>
        /// Gets the elapsed time.
        /// </summary>
        /// <returns>The elapsed time.</returns>
        public TimeSpan GetElapsedTime()
        {
            return _apiTimer.Elapsed;
        }

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

        protected void StopTimer()
        {
            _apiTimer.Stop();
        }
    }
}
