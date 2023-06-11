using Hunty.Chat.Transverse.Models.Response.Room;
using Hunty.Chat.Transverse.Models.Response.User;

namespace Hunty.Chat.Transverse.Models.Response.Conversation
{
    public class ConversationResponse
    {
        public int Id { get; set; }

        public UserResponse User { get; set; }

        public RoomResponse Room { get; set; }
    }
}
