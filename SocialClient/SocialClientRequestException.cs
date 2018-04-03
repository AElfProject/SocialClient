using System;
using System.Runtime.Serialization;

namespace SocialClient
{
    [Serializable]
    public class SocialClientRequestException : Exception
    {
        public SocialClientRequestExceptionTypes Type { get; set; }
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public SocialClientRequestException()
        {
        }

        public SocialClientRequestException(SocialClientRequestExceptionTypes message) : base(message.ToString())
        {
            Type = message;
        }

        public SocialClientRequestException(SocialClientRequestExceptionTypes message, Exception inner) : base(message.ToString(), inner)
        {
            Type = message;
        }

        protected SocialClientRequestException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}