namespace Hunty.Chat.Transverse.Models.Response
{
    public class BaseApiResponseWithData : BaseApiResponse
    {
        public virtual object Data { get; set; }
    }
}
