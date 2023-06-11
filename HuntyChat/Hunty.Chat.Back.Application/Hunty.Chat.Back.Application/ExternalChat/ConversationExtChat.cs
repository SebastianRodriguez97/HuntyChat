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
    public class ConversationExtChat
    {
        private readonly IConsumeExternalService _consumeExternalService;
        private readonly Enpoints _endpoints;
        private readonly IMapper _mapper;
        private readonly TokenAPI _tokenAPI;

        public ConversationExtChat(IMapper mapper, IConsumeExternalService consumeExternalService, IOptions<HuntyChatBackAPIKeys> tpBackApiKeys, TokenAPI tokenAPI)
        {
            _mapper = mapper;
            _consumeExternalService = consumeExternalService;
            _endpoints = tpBackApiKeys.Value.Endpoints;
            _tokenAPI = tokenAPI;
        }

        public async Task<bool> AddMember(string idConversation, string idUser)
        {
            string url = string.Format(_endpoints.AddMember, idConversation, idUser);

            BaseApiResponse response =
               await _consumeExternalService.RestAsync<BaseApiResponseWithData>(url, HttpMethod.Put, null, _tokenAPI.GetAPIKeyHeader());

            return response.StatusCode == (int)StatusCodeEnum.NO_CONTENT;
        }
    }
}
