using System;
using System.Runtime.Serialization;

namespace SocialClient
{
    [Serializable]
    public class SocialClientException : Exception
    {
        public SocialClientExceptionTypes Type { get; set; }
        public string ResponseContent { get; set; }

        public SocialClientException()
        {
        }

        public SocialClientException(SocialClientExceptionTypes message) : base(message.ToString())
        {
            Type = message;
        }

        public SocialClientException(SocialClientExceptionTypes message, String responseContent, Exception inner) : base(message.ToString(), inner)
        {
            Type = message;
            ResponseContent = responseContent;
        }

        protected SocialClientException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}