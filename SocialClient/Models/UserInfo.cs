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

    /// <summary>
    /// 社交网络里面的任何一个用户
    /// </summary>
    public class UserInfo
    {
        public string Id { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 小头像
        /// </summary>
        public string SmallAvatar { get; set; }
        /// <summary>
        /// 中头像
        /// </summary>
        public string MediumAvatar { get; set; }
        /// <summary>
        /// 大头像
        /// </summary>
        public string LargeAvatar { get; set; }
        
        /// <summary>
        /// 被关注数量
        /// </summary>
        public int Followers { get; set; }
        
        /// <summary>
        /// 正在关注数量
        /// </summary>
        public int Following { get; set; }
    }
}