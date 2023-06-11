using Hunty.Chat.Transverse.Models.Response;
using static Hunty.Chat.Transverse.Models.Response.ResponseCode;

namespace Hunty.Chat.Transverse.Helpers
{
    public static class ResponseHelper
    {
        public static BaseApiResponse SetResponse(int statusCode, string status, string message)
            => new BaseApiResponse()
            {
                StatusCode = statusCode,
                Status = status,
                Message = message
            };

        public static BaseApiResponse SetResponseWithData(int statusCode, string status, string message, object data)
            => new BaseApiResponseWithData()
            {
                StatusCode = statusCode,
                Status = status,
                Message = message,
                Data = data
            };

        public static BaseApiResponse SetResponse(StatusCodeEnum statusCode, string status, string message)
            => new BaseApiResponse()
            {
                StatusCode = (int)statusCode,
                Status = status,
                Message = message
            };

        public static BaseApiResponse SetResponseWithData(StatusCodeEnum statusCode, string status, string message, object data)
            => new BaseApiResponseWithData()
            {
                StatusCode = (int)statusCode,
                Status = status,
                Message = message,
                Data = data
            };

        public static BaseApiResponse SetSuccessResponse(string message = null)
            => new BaseSuccessApiResponse()
            {
                Message = message ?? StatusMessage[StatusCodeEnum.OK]
            };

        public static BaseApiResponse SetSuccessResponseWithData(object data, string message = null)
            => new BaseSuccessApiResponseWithData()
            {
                Message = message ?? StatusMessage[StatusCodeEnum.OK],
                Data = data
            };

        public static BaseApiResponse SetBadRequestResponse(string message = null)
            => new BaseBadRequestApiResponse()
            {
                Message = message ?? StatusMessage[StatusCodeEnum.BAD_REQUEST]
            };

        public static BaseApiResponse SetBadRequestResponseWithError(object error, string message = null)
            => new BaseBadRequestApiResponseWithError()
            {
                Message = message ?? StatusMessage[StatusCodeEnum.BAD_REQUEST],
                Error = error
            };

        public static BaseApiResponse SetInternalServerErrorResponse(string message = null)
           => new BaseApiResponse()
           {
               StatusCode = (int)StatusCodeEnum.INTERNAL_SERVER_ERROR,
               Status = Status[StatusCodeEnum.INTERNAL_SERVER_ERROR],
               Message = message ?? StatusMessage[StatusCodeEnum.INTERNAL_SERVER_ERROR]
           };
    }
}
