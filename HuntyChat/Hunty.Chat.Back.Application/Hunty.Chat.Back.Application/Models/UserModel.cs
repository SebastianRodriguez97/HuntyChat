using System;

namespace Hunty.Chat.Back.Application.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string AccessToken { get; set; }
        public DateTime ExpiredDate { get; set; }
    }
}
