using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Hunty.Chat.Back.Database.Entities
{
    [Table("Messages", Schema = "Chat")]
    public class Messages
    {
       public int Id { get; set; }

        public string Text { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsFromWebhook { get; set; }
        public int Id_Conversation { get; set; }

        public virtual Conversations Conversation { get; set; }
    }
}
