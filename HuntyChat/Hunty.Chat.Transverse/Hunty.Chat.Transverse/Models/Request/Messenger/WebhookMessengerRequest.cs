using System;

namespace Hunty.Chat.Transverse.Models.Request.Messenger
{
    public class WebhookMessengerRequest
    {
        public int id { get; set; }
        public string action { get; set; }
        public ActorWebhookMessengerRequest actor { get; set; }
        public MessageWebhookMessengerRequest message { get; set; }
    }

    public class ActorWebhookMessengerRequest
    {
        public int id { get; set; }
        public string uid { get; set; }
        public string display_name { get; set; }
    }
    
    public class MessageWebhookMessengerRequest
    {
        public int id { get; set; }
        public int app_id { get; set; }
        public DateTime created_at { get; set; }
    }
}
