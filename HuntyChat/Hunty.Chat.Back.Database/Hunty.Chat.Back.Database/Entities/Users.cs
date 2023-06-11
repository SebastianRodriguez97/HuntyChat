using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Hunty.Chat.Back.Database.Entities
{
    [Table("Users", Schema = "Chat")]
    public class Users
    {
        public Users()
        {
            Conversations = new HashSet<Conversations>();
        }

        public int Id { get; set; }
        public string Uid { get; set; }
        public string Name { get; set; }
        public string AccessToken { get; set; }
        public DateTime ExpirationToken { get; set; }

        public virtual ICollection<Conversations> Conversations { get; set; }
    }
}
