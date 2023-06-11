using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hunty.Chat.Back.Application.Repository.Implementations;
using Hunty.Chat.Back.Application.Services.V1.Interfaces;
using Hunty.Chat.Back.Database.Entities;
using Hunty.Chat.Transverse.Helpers;
using Hunty.Chat.Transverse.Models.Response.City;
using Microsoft.Extensions.Options;
using Hunty.Chat.Back.Application.Utilities.AppSettingsKeys;
using Hunty.Chat.Transverse.ExternalServices;
using System.Net.Http;
using Hunty.Chat.Transverse.Models.Response;
using Hunty.Chat.Back.Application.Utilities.Authentication;
using Hunty.Chat.Back.Application.ExternalChat;
using Hunty.Chat.Back.Application.Models.ExternalChat.Response;
using Hunty.Chat.Back.Application.Models;
using System;

namespace Hunty.Chat.Back.Application.Services.V1.Implementations
{
    public class ConversationService : IConversationService
    {
        private readonly IMapper _mapper;
        private readonly ConversationRepository _conversationRepository;
        private readonly ConversationExtChat _conversationExtChat;

        public ConversationService(
            IMapper mapper, 
            ConversationRepository conversationRepository,
            ConversationExtChat conversationExtChat)
        {
            _conversationExtChat = conversationExtChat;
            _mapper = mapper;
            _conversationRepository = conversationRepository;
        }

        public async Task<ConversationModel> GetUserConversation(string codeUser)
        {
            Conversations conversation = await _conversationRepository.GetLastConversationByUserCode(codeUser);
                        
            return _mapper.Map<Conversations, ConversationModel>(conversation);
        }

        public async Task<bool> AddMember(string idRoom, string idUser)
        {
            bool isMemberAdded = await _conversationExtChat.AddMember(idRoom, idUser);

            if (isMemberAdded)
                isMemberAdded = await _conversationRepository.AddUser(idRoom, idUser);

            return isMemberAdded;
        }

        public async Task<Conversations> GetById(int id)
        {
            return await _conversationRepository.GetAsync(id);
        }
    }
}
