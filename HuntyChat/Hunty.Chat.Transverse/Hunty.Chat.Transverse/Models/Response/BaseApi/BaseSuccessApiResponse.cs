using static Hunty.Chat.Transverse.Models.Response.ResponseCode;

namespace Hunty.Chat.Transverse.Models.Response
{
    public class BaseSuccessApiResponse : BaseApiResponse
    {
        public override string Status { get; set; }
        public override int StatusCode { get; set; }
        public override string Message { get; set; }

        public BaseSuccessApiResponse()
        {
            Status = ResponseCode.Status[StatusCodeEnum.OK];
            StatusCode = (int)StatusCodeEnum.OK;
            Message = ResponseCode.StatusMessage[StatusCodeEnum.OK];
        }
    }
}
