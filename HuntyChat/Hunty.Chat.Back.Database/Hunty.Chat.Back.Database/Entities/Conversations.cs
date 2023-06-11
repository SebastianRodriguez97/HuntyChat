using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hunty.Chat.Back.Database.Entities
{
    [Table("Conversations", Schema = "Chat")]
    public class Conversations
    {
        public Conversations()
        {
            Messages = new HashSet<Messages>();
        }

        public int Id { get; set; }

        public int Id_User { get; set; }
        public int Id_Room { get; set; }

        public virtual Users User { get; set; }
        public virtual Rooms Room { get; set; }

        public virtual ICollection<Messages> Messages { get; set; }
    }
}
