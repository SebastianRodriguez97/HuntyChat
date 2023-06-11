using static Hunty.Chat.Transverse.Models.Response.ResponseCode;

namespace Hunty.Chat.Transverse.Models.Response
{
    public class BaseBadRequestApiResponse : BaseApiResponse
    {
        public override string Status { get; set; }
        public override int StatusCode { get; set; }
        public override string Message { get; set; }

        public BaseBadRequestApiResponse()
        {
            Status = ResponseCode.Status[StatusCodeEnum.BAD_REQUEST];
            StatusCode = (int)StatusCodeEnum.BAD_REQUEST;
            Message = ResponseCode.StatusMessage[StatusCodeEnum.BAD_REQUEST];
        }
    }
}
