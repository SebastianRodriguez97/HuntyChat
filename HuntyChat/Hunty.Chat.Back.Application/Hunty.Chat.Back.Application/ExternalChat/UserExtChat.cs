using AutoMapper;
using Hunty.Chat.Back.Application.Models.ExternalChat.Request;
using Hunty.Chat.Back.Application.Models.ExternalChat.Response;
using Hunty.Chat.Back.Application.Utilities.AppSettingsKeys;
using Hunty.Chat.Back.Application.Utilities.Authentication;
using Hunty.Chat.Transverse.ExternalServices;
using Hunty.Chat.Transverse.Models.Response;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static Hunty.Chat.Transverse.Models.Response.ResponseCode;

namespace Hunty.Chat.Back.Application.ExternalChat
{
    public class UserExtChat
    {
        private readonly IConsumeExternalService _consumeExternalService;
        private readonly Enpoints _endpoints;
        private readonly IMapper _mapper;
        private readonly TokenAPI _tokenAPI;

        public UserExtChat(IMapper mapper, IConsumeExternalService consumeExternalService, IOptions<HuntyChatBackAPIKeys> tpBackApiKeys, TokenAPI tokenAPI)
        {
            _mapper = mapper;
            _consumeExternalService = consumeExternalService;
            _endpoints = tpBackApiKeys.Value.Endpoints;
            _tokenAPI = tokenAPI;
        }

        public async Task<GetAccessTokenResponse> GetAccessToken(string codeUser)
        {
            string url = string.Format(_endpoints.GetAccessToken, codeUser);
            GetAccessTokenRequest getAccessToken = new GetAccessTokenRequest()
            {
                expires_in = 10000
            };

            BaseApiResponseWithData response =
               await _consumeExternalService.RestAsync<BaseApiResponseWithData>(url, HttpMethod.Post, getAccessToken, _tokenAPI.GetAPIKeyHeader());

            if (response.StatusCode != (int)StatusCodeEnum.OK)
                return null;

            return JsonConvert.DeserializeObject<GetAccessTokenResponse>(response.Data.ToString());
        }

        public async Task<GetUserResponse> Get(string codeUser)
        {
            string url = string.Format(_endpoints.GetUser, codeUser);

            BaseApiResponseWithData response =
               await _consumeExternalService.RestAsync<BaseApiResponseWithData>(url, HttpMethod.Get, null, _tokenAPI.GetAPIKeyHeader());

            if (response.StatusCode != (int)StatusCodeEnum.CREATED && response.StatusCode != (int)StatusCodeEnum.OK)
                return null;

            return JsonConvert.DeserializeObject<GetUserResponse>(response.Data.ToString());
        }
    }
}
