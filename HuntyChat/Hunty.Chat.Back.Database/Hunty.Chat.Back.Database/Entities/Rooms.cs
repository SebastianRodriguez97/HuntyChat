using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace Hunty.Chat.Back.Database.Entities
{
    [Table("Rooms", Schema = "Chat")]
    public class Rooms
    {
        public Rooms()
        {
            Conversations = new HashSet<Conversations>();
        }

        public int Id { get; set; }

        public string Uid { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Conversations> Conversations { get; set; }
    }
}
