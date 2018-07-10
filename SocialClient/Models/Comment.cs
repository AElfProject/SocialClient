namespace SocialClient.Models
{
    public class Comment
    {
        public string Id { get; set; }
        
        public string PostId { get; set; }
        
        public string Content { get; set; }
        
        public string ExternalLink { get; set; }
    }
}