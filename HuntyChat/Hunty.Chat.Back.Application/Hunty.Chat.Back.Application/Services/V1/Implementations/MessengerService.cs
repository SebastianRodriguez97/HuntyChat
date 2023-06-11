using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hunty.Chat.Back.Application.Repository.Implementations;
using Hunty.Chat.Back.Application.Services.V1.Interfaces;
using Hunty.Chat.Back.Database.Entities;
using Hunty.Chat.Transverse.Helpers;
using Hunty.Chat.Transverse.Models.Request.Messenger;
using Hunty.Chat.Back.Application.Models;
using System;
using Hunty.Chat.Back.Application.ExternalChat;
using Hunty.Chat.Back.Application.Models.ExternalChat.Response;
using Hunty.Chat.Transverse.Models.Response.Message;

namespace Hunty.Chat.Back.Application.Services.V1.Implementations
{
    public class MessengerService : IMessengerService
    {
        private readonly IMapper _mapper;
        private readonly MessageRepository _messageRepository;
        private readonly IConversationService _conversationService;
        private readonly IRoomService _roomService;
        private readonly IUserService _userService;
        private readonly MessengerExtChat _messengerExtChat;

        public MessengerService(
            IMapper mapper, 
            MessageRepository messageRepository,
            IConversationService conversationService,
            IUserService userService,
            IRoomService roomService,
            MessengerExtChat messengerExtChat)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
            _conversationService = conversationService;
            _roomService = roomService;
            _userService = userService;
            _messengerExtChat = messengerExtChat;
        }

        public async Task<object> InBoundMessages(WebhookMessengerRequest webhookMessengerRequest)
        {
            MessageModel messageModel = _mapper.Map<WebhookMessengerRequest, MessageModel>(webhookMessengerRequest);

            Messages messages = await _messageRepository.GetByIdAsync(int.Parse(messageModel.Id));
            if (messages is null)
            {
                GetMessageResponse message = await _messengerExtChat.GetMessage(messageModel.Id);

                if (message is null)
                    return ResponseHelper.SetInternalServerErrorResponse();

                ConversationModel conversation = await _conversationService.GetUserConversation(messageModel.Conversation.User.Code);

                messageModel.Text = message.text;
                messageModel.Conversation.Id = conversation.Id;
                messageModel = await SaveMessage(messageModel);
            }            

            return ResponseHelper.SetSuccessResponseWithData(messageModel);
        }

        public async Task<object> OutBoundMessages(SendMessageMessengerRequest sendMessageMessengerRequest)
        {
            CreateMessageResponse createMessageResponse;
            bool isMemberAdded;

            RoomModel Room = await _roomService.GetMyActiveRoom();
            UserModel user = await _userService.GetUserWithAuthAlive(sendMessageMessengerRequest.codeUser);

            ConversationModel conversation = await _conversationService.GetUserConversation(user.Code);

            if (conversation is null) {
                isMemberAdded = await _conversationService.AddMember(Room.Id.ToString(), user.Id);
                if (isMemberAdded)
                    conversation = await _conversationService.GetUserConversation(user.Code);
            }
            else
                isMemberAdded = true;

            if (!isMemberAdded)
                return ResponseHelper.SetBadRequestResponse();

            createMessageResponse = await _messengerExtChat.CreateMessage(conversation, sendMessageMessengerRequest.textMessage);
            if (createMessageResponse is null)
                return ResponseHelper.SetBadRequestResponse();

            MessageModel message = _mapper.Map<CreateMessageResponse, MessageModel>(createMessageResponse);
            message.Conversation.Id = conversation.Id;
            message = await SaveMessage(message);
            return ResponseHelper.SetSuccessResponseWithData(_mapper.Map<MessageModel, MessageResponse>(message));            
        }

        public async Task<object> GetAllMessagesFromWebhook()
        {
            List<Messages> messages = await _messageRepository.GetAllMessagesFromWebhookAsync();
            List<MessageResponse> messageResponse = _mapper.Map<List<Messages>, List<MessageResponse>>(messages);

            return ResponseHelper.SetSuccessResponseWithData(messageResponse);
        }

        private async Task<MessageModel> SaveMessage(MessageModel messageModel)
        {
            Messages message = _mapper.Map<MessageModel, Messages>(messageModel);
            Conversations conversation = await _conversationService.GetById(messageModel.Conversation.Id);
            message.Conversation = conversation;
            message = await _messageRepository.AddAsync(message);

            return _mapper.Map<Messages, MessageModel>(message);
        }
    }
}
