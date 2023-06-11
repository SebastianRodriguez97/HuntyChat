using System.Collections.Generic;
namespace Hunty.Chat.Transverse.Models.Response
{
    public static class ResponseCode
    {
        public enum StatusCodeEnum
        {
            OK = 200,
            CREATED = 201,
            NO_CONTENT = 204,
            BAD_REQUEST = 400,
            UNAUTHORIZED = 401,
            FORBIDDEN = 403,
            NOT_FOUND = 404,
            INTERNAL_SERVER_ERROR = 500
        }

        public static Dictionary<StatusCodeEnum, string> Status = new Dictionary<StatusCodeEnum, string>()
        {
            { StatusCodeEnum.OK, "Ok" },
            { StatusCodeEnum.CREATED, "Created" },
            { StatusCodeEnum.BAD_REQUEST, "BadRequest" },
            { StatusCodeEnum.UNAUTHORIZED, "Unauthorized" },
            { StatusCodeEnum.FORBIDDEN, "Forbbiden" },
            { StatusCodeEnum.NOT_FOUND, "NotFound" },
            { StatusCodeEnum.INTERNAL_SERVER_ERROR, "InternalServerError" },
        };

        public static Dictionary<StatusCodeEnum, string> StatusMessage = new Dictionary<StatusCodeEnum, string>()
        {
            { StatusCodeEnum.OK, "Success" },
            { StatusCodeEnum.CREATED, "Created successfully" },
            { StatusCodeEnum.BAD_REQUEST, "Something went wrong" },
            { StatusCodeEnum.UNAUTHORIZED, "Unauthorization error" },
            { StatusCodeEnum.FORBIDDEN, "Access denied" },
            { StatusCodeEnum.NOT_FOUND, "Resource not found" },
            { StatusCodeEnum.INTERNAL_SERVER_ERROR, "Internal server error" },
        };
    }
}
