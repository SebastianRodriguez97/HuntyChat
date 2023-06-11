namespace Hunty.Chat.Back.Application.Models.ExternalChat.Response
{
    public class GetMessageResponse
    {
        public int id { get; set; }
        public int app_id { get; set; }
        public string text { get; set; }
    }
}
