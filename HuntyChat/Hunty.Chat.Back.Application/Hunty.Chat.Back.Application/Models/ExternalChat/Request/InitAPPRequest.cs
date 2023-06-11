namespace Hunty.Chat.Back.Application.Models.ExternalChat.Request
{
   public class InitAPPRequest
    {
        public APPModelRequest app { get; set; }
    }

    public class APPModelRequest
    {
        public string uid { get; set; }
        public string type { get; set; }
        public string name { get; set; }
    }
}
