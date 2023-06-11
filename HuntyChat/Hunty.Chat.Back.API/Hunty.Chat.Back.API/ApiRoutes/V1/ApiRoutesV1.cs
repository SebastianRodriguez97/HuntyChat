namespace Hunty.Chat.Back.API.ApiRoutes.V1
{
    public static class ApiRoutesV1
    {
        public const string Base = "api/v1";

        public static class Message
        {
            public const string MessageBase = Base + "/messages";
        }

        public static class User
        {
            public const string UserBase = Base + "/user";
            public const string GetAccessToken = UserBase + "/getAccessToken";
        }
    }
}
