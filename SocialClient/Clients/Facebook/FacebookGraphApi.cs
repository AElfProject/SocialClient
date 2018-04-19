namespace SocialClient.Clients.Facebook
{
    public class FacebookGraphApi: FacebookApi
    {
        public FacebookGraphApi(FacebookOAuth facebookOAuth): this(facebookOAuth, "v2.12")
        {
        }

        public FacebookGraphApi(FacebookOAuth facebookOAuth, string version) : base("https://graph.facebook.com/", facebookOAuth, version)
        {
        }
    }
}
