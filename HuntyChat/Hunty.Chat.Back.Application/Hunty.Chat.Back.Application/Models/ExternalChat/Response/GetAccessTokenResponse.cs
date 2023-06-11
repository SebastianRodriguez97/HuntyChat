using System;
using System.Collections.Generic;
using System.Text;

namespace Hunty.Chat.Back.Application.Models.ExternalChat.Response
{
    public class GetAccessTokenResponse
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
    }
}
