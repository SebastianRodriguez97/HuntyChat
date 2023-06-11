using AutoMapper;
using Hunty.Chat.Back.Application.Models;
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
    public class MessengerExtChat
    {
        private readonly IConsumeExternalService _consumeExternalService;
        private readonly Enpoints _endpoints;
        private readonly IMapper _mapper;
        private readonly TokenAPI _tokenAPI;

        public MessengerExtChat(IMapper mapper, IConsumeExternalService consumeExternalService, IOptions<HuntyChatBackAPIKeys> tpBackApiKeys, TokenAPI tokenAPI)
        {
            _mapper = mapper;
            _consumeExternalService = consumeExternalService;
            _endpoints = tpBackApiKeys.Value.Endpoints;
            _tokenAPI = tokenAPI;
        }

        public async Task<CreateMessageResponse> CreateMessage(ConversationModel conversationModel, string textMessage)
        {
            string url = string.Format(_endpoints.CreateMessage, conversationModel.Room.Id);
            CreateMessageRequest messageRequest = new CreateMessageRequest()
            {
                text = textMessage
            };

            BaseApiResponseWithData response =
               await _consumeExternalService.RestAsync<BaseApiResponseWithData>(url, HttpMethod.Post, messageRequest, _tokenAPI.GetAccessTokenHeader(conversationModel.User.AccessToken));

            if (response.StatusCode != (int)StatusCodeEnum.CREATED)
                return null;

            return JsonConvert.DeserializeObject<CreateMessageResponse>(response.Data.ToString());
        }

        public async Task<GetMessageResponse> GetMessage(string idMessage)
        {
            string url = string.Format(_endpoints.GetMessage, idMessage);

            BaseApiResponseWithData response =
               await _consumeExternalService.RestAsync<BaseApiResponseWithData>(url, HttpMethod.Get, null, _tokenAPI.GetAPIKeyHeader());

            if (response.StatusCode != (int)StatusCodeEnum.OK)
                return null;

            return JsonConvert.DeserializeObject<GetMessageResponse>(response.Data.ToString());
        }
    }
}
