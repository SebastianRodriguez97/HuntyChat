using System;
using System.Collections.Generic;
using System.Text;

namespace Hunty.Chat.Back.Application.Models.ExternalChat.Response
{
    public class CreateMessageResponse
    {
        public int id { get; set; }
        public int app_id { get; set; }
        public string text { get; set; }
        public DateTime created_at { get; set; }
        public createdMessage_byResponse created_by { get; set; }
    }

    public class createdMessage_byResponse
    {
        public int id { get; set; }
        public string uid { get; set; }
        public string display_name { get; set; }
    }
}
