using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;
using Hunty.Chat.Transverse.Helpers;
using Hunty.Chat.Transverse.Models.Response;
using Hunty.Chat.Transverse.Models.Response.Error;

namespace Hunty.Chat.Back.API.Utility.ActionFilters
{
    public class FluentValidationActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid) return;

            List<InvalidFieldModel> invalidFieldModels = new List<InvalidFieldModel>();

            foreach(string field in context.ModelState.Keys)
            {
                ModelStateEntry modelState = context.ModelState.FirstOrDefault(x => x.Key.Equals(field)).Value;

                invalidFieldModels.Add(new InvalidFieldModel()
                {
                    Field = field,
                    Errors = modelState.Errors.Select(x => x.ErrorMessage).ToList()
                });
            }

            context.Result = new JsonResult(ResponseHelper.SetBadRequestResponseWithError(invalidFieldModels, "One or more fields are wrong"))
            {
                StatusCode = (int)ResponseCode.StatusCodeEnum.BAD_REQUEST
            };
        }
    }
}
