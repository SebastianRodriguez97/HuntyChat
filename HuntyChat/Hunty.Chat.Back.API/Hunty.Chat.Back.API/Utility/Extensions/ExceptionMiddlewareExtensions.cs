using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Hunty.Chat.Transverse.Exceptions;
using Hunty.Chat.Transverse.Helpers;
using static Hunty.Chat.Transverse.Models.Response.ResponseCode;

namespace Hunty.Chat.Back.API.Utility.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger logger)
        {
            string messageError;

            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)StatusCodeEnum.INTERNAL_SERVER_ERROR;
                    context.Response.ContentType = "application/json";

                    IExceptionHandlerFeature contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeature != null)
                    {
                        logger.LogError("Something went wrong: {Servicio} | {Error}", "Portafolio API", contextFeature.Error);

                        if (contextFeature.Error is ApiException apiException)
                        {
                            context.Response.StatusCode = (int)apiException.HttpStatusCode;
                            messageError = apiException.Message;
                        }
                        else
                            messageError = contextFeature.Error.Message;

                        ResponseHelper.SetInternalServerErrorResponse(messageError);

                        await context.Response.WriteAsync(
                            JsonConvert.SerializeObject(
                                ResponseHelper.SetResponse(
                                    (StatusCodeEnum)context.Response.StatusCode,
                                    Status[(StatusCodeEnum)context.Response.StatusCode],
                                    messageError
                            )));
                    }
                });
            });
        }
    }
}