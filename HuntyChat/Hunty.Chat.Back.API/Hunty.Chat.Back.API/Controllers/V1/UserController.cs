using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Hunty.Chat.Back.API.ApiRoutes.V1;
using Hunty.Chat.Back.Application.Services.V1.Interfaces;
using Hunty.Chat.Back.Application.Models;
using Hunty.Chat.Transverse.Helpers;

namespace Hunty.Chat.Back.API.Controllers.V1
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet(ApiRoutesV1.User.GetAccessToken)]
        public async Task<IActionResult> GetAccessToken()
        {
            UserModel user = new UserModel()
            {
                Id = "5",
                Code = "FrontendUser",
                Name = "Frontend User"
            };

            user = await _userService.GetAccessToken(user);
            return Ok(ResponseHelper.SetSuccessResponseWithData(user.AccessToken));
        }
    }
}
