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
    public class RoomExtChat
    {
        private readonly IConsumeExternalService _consumeExternalService;
        private readonly Enpoints _endpoints;
        private readonly IMapper _mapper;
        private readonly TokenAPI _tokenAPI;

        public RoomExtChat(IMapper mapper, IConsumeExternalService consumeExternalService, IOptions<HuntyChatBackAPIKeys> tpBackApiKeys, TokenAPI tokenAPI)
        {
            _mapper = mapper;
            _consumeExternalService = consumeExternalService;
            _endpoints = tpBackApiKeys.Value.Endpoints;
            _tokenAPI = tokenAPI;
        }

        public async Task<InitAPPResponse> InitRoom(RoomModel room)
        {
            InitAPPRequest initAPP = new InitAPPRequest()
            {
                app = new APPModelRequest()
                {
                    uid = room.Uid,
                    name = room.Name,
                    type = "Chat"
                }
            };

            BaseApiResponseWithData response =
               await _consumeExternalService.RestAsync<BaseApiResponseWithData>(_endpoints.InitAPP, HttpMethod.Post, initAPP, _tokenAPI.GetAPIKeyHeader());

            if (response.StatusCode != (int)StatusCodeEnum.OK)
                return null;

            return JsonConvert.DeserializeObject<InitAPPResponse>(response.Data.ToString());
        }
    }
}
