using System;

namespace Hunty.Chat.Transverse.Models.Response.User
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Uid { get; set; }
        public string Name { get; set; }
        public string AccessToken { get; set; }
        public DateTime ExpirationToken { get; set; }
    }
}
