using System;
using System.Collections.Generic;
using SocialClient.Clients.Facebook.ApiEngine;
using System.Threading.Tasks;
using SocialClient.Clients.Facebook.Interfaces;
using Xunit;
using SocialClient.Models.Facebook;

namespace SocialClient.Tests
{
    public class FacebookTests
    {
        [Fact]
        public async Task TestGetFeed()
        {
            var accesstoken = "EAACEdEose0cBAPGx39C3rDaEqnKP3ZBNFQiRd6kk26aIZB96lZCs3M5u2jufj0n7QAKrIZCLEObuKwPBkITyBvKvR0kzXGvM1lEdOJhOUptWeiwoZA4kjQpondTSGtZAcckuy96ujLnHaDkxFNeYHPA5W4ZAUrc7uQaYY4URc66XpI2unMP50ZBB2Av9xvmXkomE1D86ucyTZCgZDZD";
            var apiClient = new ApiClient
            {
                AccessToken = accesstoken,
                Proxy = "127.0.0.1:1080",
                AppKey = "",
                AppSecret = ""
            };
            var homePageId = "172265013481168";
            var resource = $"{homePageId}/feed";
            var pagedRequest =
                (IPagedRequest)ApiRequest.Create(resource, apiClient);
           
            pagedRequest.AddPageLimit(2);

            var result = new List<FacebookActionData>();
            var pagedResultResponse = pagedRequest.ExecutePage<FacebookActionData>();
            if (pagedResultResponse.IsDataAvailable())
            {
                result.AddRange(pagedResultResponse.GetResultData());
                while (pagedResultResponse.IsNextPageDataAvailable())
                {
                    pagedResultResponse = pagedResultResponse.GetNextPageData();
                    result.AddRange(pagedResultResponse.GetResultData());
                }
            }

            foreach (var r in result)
            {
                Console.WriteLine(r.Id);
                Console.WriteLine(r.Name);
            }
        }

        [Fact]
        public async Task TestGetPageLikes()
        {
            var accesstoken = "EAACEdEose0cBAPGx39C3rDaEqnKP3ZBNFQiRd6kk26aIZB96lZCs3M5u2jufj0n7QAKrIZCLEObuKwPBkITyBvKvR0kzXGvM1lEdOJhOUptWeiwoZA4kjQpondTSGtZAcckuy96ujLnHaDkxFNeYHPA5W4ZAUrc7uQaYY4URc66XpI2unMP50ZBB2Av9xvmXkomE1D86ucyTZCgZDZD";
            var apiClient = new ApiClient
            {
                AccessToken = accesstoken,
                Proxy = "127.0.0.1:1080",
                AppKey = "",
                AppSecret = ""
            };
            var pageId = "172265013481168_172327573474912";
            var resource = $"{pageId}/likes";
            var pagedRequest =
                (IPagedRequest)ApiRequest.Create(resource, apiClient);
            
            pagedRequest.AddPageLimit(1);

            var result = new List<FacebookActionData>();
            var pagedResultResponse = pagedRequest.ExecutePage<FacebookActionData>();
            if (pagedResultResponse.IsDataAvailable())
            {
                result.AddRange(pagedResultResponse.GetResultData());
                while (pagedResultResponse.IsNextPageDataAvailable())
                {
                    pagedResultResponse = pagedResultResponse.GetNextPageData();
                    result.AddRange(pagedResultResponse.GetResultData());
                }
            }

            foreach (var r in result)
            {
                Console.WriteLine(r.Id);
                Console.WriteLine(r.Name);
            }
        }

        [Fact]
        public async Task TestGetPageComments()
        {
            var accesstoken = "EAACEdEose0cBAPGx39C3rDaEqnKP3ZBNFQiRd6kk26aIZB96lZCs3M5u2jufj0n7QAKrIZCLEObuKwPBkITyBvKvR0kzXGvM1lEdOJhOUptWeiwoZA4kjQpondTSGtZAcckuy96ujLnHaDkxFNeYHPA5W4ZAUrc7uQaYY4URc66XpI2unMP50ZBB2Av9xvmXkomE1D86ucyTZCgZDZD";
            var apiClient = new ApiClient
            {
                AccessToken = accesstoken,
                Proxy = "127.0.0.1:1080",
                AppKey = "",
                AppSecret = ""
            };
            var pageId = "172265013481168_172327573474912";
            var resource = $"{pageId}/comments";
            var pagedRequest =
                (IPagedRequest)ApiRequest.Create(resource, apiClient);
            pagedRequest.AddQueryParameter("order", "reverse_chronological");
            //pagedRequest.AddQueryParameter("","");

            pagedRequest.AddPageLimit(3);

            var result = new List<FacebookActionData>();
            var pagedResultResponse = pagedRequest.ExecutePage<FacebookActionData>();
            if (pagedResultResponse.IsDataAvailable())
            {
                result.AddRange(pagedResultResponse.GetResultData());
                while (pagedResultResponse.IsNextPageDataAvailable())
                {
                    pagedResultResponse = pagedResultResponse.GetNextPageData();
                    result.AddRange(pagedResultResponse.GetResultData());
                }
            }

            foreach (var r in result)
            {
                Console.WriteLine(r.Id);
                Console.WriteLine(r.Name);
            }
        }

        [Fact]
        public async Task TestGetPageSharedPosts()
        {
            var accesstoken = "EAACEdEose0cBAPGx39C3rDaEqnKP3ZBNFQiRd6kk26aIZB96lZCs3M5u2jufj0n7QAKrIZCLEObuKwPBkITyBvKvR0kzXGvM1lEdOJhOUptWeiwoZA4kjQpondTSGtZAcckuy96ujLnHaDkxFNeYHPA5W4ZAUrc7uQaYY4URc66XpI2unMP50ZBB2Av9xvmXkomE1D86ucyTZCgZDZD";
            var apiClient = new ApiClient
            {
                AccessToken = accesstoken,
                Proxy = "127.0.0.1:1080",
                AppKey = "",
                AppSecret = ""
            };
            var pageId = "172265013481168_172327573474912";
            var resource = $"{pageId}/sharedposts";
            var pagedRequest =
                (IPagedRequest)ApiRequest.Create(resource, apiClient);
            pagedRequest.AddQueryParameter("fields", "from,message,created_time");

            pagedRequest.AddPageLimit(1);

            var result = new List<FacebookActionData>();
            var pagedResultResponse = pagedRequest.ExecutePage<FacebookActionData>();
            if (pagedResultResponse.IsDataAvailable())
            {
                result.AddRange(pagedResultResponse.GetResultData());
                while (pagedResultResponse.IsNextPageDataAvailable())
                {
                    pagedResultResponse = pagedResultResponse.GetNextPageData();
                    result.AddRange(pagedResultResponse.GetResultData());
                }
            }

            foreach (var r in result)
            {
                Console.WriteLine(r.Id);
                Console.WriteLine(r.Name);
            }
        }

    }
}