namespace Hunty.Chat.Back.Application.Utilities.AppSettingsKeys
{
    public class HuntyChatBackAPIKeys
    {
        public Enpoints Endpoints { get; set; }
        public string APIKey { get; set; }
    }

    public class Enpoints
    {
        public string BaseRoute { get; set; }
        public string GetAllAPPs { get; set; }
        public string InitAPP { get; set; }
        public string GetAccessToken { get; set; }
        public string GetUser { get; set; }
        public string AddMember { get; set; }
        public string CreateMessage { get; set; }
        public string GetMessage { get; set; }
    }

}
