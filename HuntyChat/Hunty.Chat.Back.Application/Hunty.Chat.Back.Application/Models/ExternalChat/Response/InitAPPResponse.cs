using System;
using System.Collections.Generic;
using System.Text;

namespace Hunty.Chat.Back.Application.Models.ExternalChat.Response
{
    public class InitAPPResponse
    {
        public int id { get; set; }
        public string uid { get; set; }
        public string type { get; set; }
        public string display_name { get; set; }
    }
}
