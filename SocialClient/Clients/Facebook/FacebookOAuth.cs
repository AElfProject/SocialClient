namespace SocialClient.Clients
{
    public class FacebookOAuth: OAuth
    {
        public string GrantType { get; set; }
        public string ExchangeToken { get; set; }
        public int ExpireAt { get; set; } = 0;
    }
}