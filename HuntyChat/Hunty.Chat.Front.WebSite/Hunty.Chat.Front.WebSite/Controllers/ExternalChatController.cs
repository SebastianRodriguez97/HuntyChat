using Hunty.Chat.Front.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hunty.Chat.Front.WebSite.Controllers
{
    public class ExternalChatController : Controller
    {
        private readonly IUserService userService;

        public ExternalChatController(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            string accessToken = await userService.GetAccessToken();

            ViewBag.url = "url";
            ViewBag.token = accessToken;

            return View();
        }
    }
}
