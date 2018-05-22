using System;
using System.Collections.Generic;
using System.Text;
using RestSharp.Deserializers;

namespace SocialClient.Clients.Facebook.Entities
{
     /// <summary>
    /// Represents paging object
    /// </summary>
    public class Paging
    {
        
        /// <summary>
        /// Next page url
        /// </summary>
        [DeserializeAs(Name = "next")]
        public string Next { get; set; }

        /// <summary>
        /// Previous page url
        /// </summary>
        [DeserializeAs(Name = "previous")]
        public string Previous { get; set; }

        /// <summary>
        /// Cursors
        /// </summary>
        [DeserializeAs(Name = "cursors")]
        public Cursors Cursors { get; set; }
    }

    /// <summary>
    /// Page cursors
    /// </summary>
    public class Cursors
    {
        /// <summary>
        /// Cursor for previous page
        /// </summary>
        [DeserializeAs(Name = "before")]
        public string Before { get; set; }

        /// <summary>
        /// Cursor for next page
        /// </summary>
        [DeserializeAs(Name = "after")]
        public string After { get; set; }

    }
}
