namespace SocialClient.Models
{
    /// <summary>
    /// 用户自己的信息
    /// </summary>
    public class AccountInfo: UserInfo
    {
        public string Email { get; set; }
        
        public string Username { get; set; }
    }
}