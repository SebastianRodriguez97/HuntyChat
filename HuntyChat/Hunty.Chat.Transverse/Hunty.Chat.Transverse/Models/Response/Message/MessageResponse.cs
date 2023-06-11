using Hunty.Chat.Transverse.Models.Response.Conversation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hunty.Chat.Transverse.Models.Response.Message
{
    public class MessageResponse
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public ConversationResponse Conversation { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsFromWebhook { get; set; }
    }
}
