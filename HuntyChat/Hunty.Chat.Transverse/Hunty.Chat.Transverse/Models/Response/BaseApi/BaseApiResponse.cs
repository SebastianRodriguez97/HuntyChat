namespace Hunty.Chat.Transverse.Models.Response
{
    public class BaseApiResponse
    {
        public virtual string Status { get; set; }
        public virtual int StatusCode { get; set; }
        public virtual string Message { get; set; }
    }
}
