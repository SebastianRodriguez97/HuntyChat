using System;
using System.Collections.Generic;
using System.Text;

namespace Hunty.Chat.Back.Application.Models
{
    public class ConversationModel
    {
        public int Id { get; set; }
        public RoomModel Room { get; set; }
        public UserModel User { get; set; }
    }
}
