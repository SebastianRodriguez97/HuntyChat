using System;

namespace Hunty.Chat.Back.Application.Models
{
    public class MessageModel
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsFromWebhook { get; set; }
        public ConversationModel Conversation { get; set; }
    }
}
