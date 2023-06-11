using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hunty.Chat.Front.Application.Repository.Interfaces;
using Hunty.Chat.Front.Application.Services.Interfaces;
using Hunty.Chat.Transverse.Models.Response;
using static Hunty.Chat.Transverse.Models.Response.ResponseCode;

namespace Hunty.Chat.Front.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<string> GetAccessToken()
        {
            BaseApiResponseWithData response = await userRepository.GetAccessToken();
            if (response.StatusCode != (int)StatusCodeEnum.OK)
                return string.Empty;

            response = JsonConvert.DeserializeObject<BaseApiResponseWithData>(response.Data.ToString());

            return response?.Data?.ToString();
        }
    }
}
