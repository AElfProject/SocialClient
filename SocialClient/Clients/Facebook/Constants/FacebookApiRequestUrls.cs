using System;
using System.Collections.Generic;
using System.Text;

namespace SocialClient.Clients.Facebook.Constants
{
    /// <summary>
    /// Represents collection of Facebook api request urls
    /// </summary>
    internal static class FacebookApiRequestUrls
    {
        /// <summary>
        /// Base url for any graph request
        /// </summary>
        public static string GRAPH_REQUEST_BASE_URL = "https://graph.facebook.com/{api_version}";

        /// <summary>
        /// Base url for any graph request
        /// </summary>
        public static string GRAPH_REQUEST_VERSION = "v2.12";
    }
}
