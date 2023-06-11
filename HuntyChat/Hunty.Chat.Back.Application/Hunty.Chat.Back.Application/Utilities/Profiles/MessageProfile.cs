using AutoMapper;
using Hunty.Chat.Back.Application.Models;
using Hunty.Chat.Back.Application.Models.ExternalChat.Response;
using Hunty.Chat.Back.Database.Entities;
using Hunty.Chat.Transverse.Models.Request.Messenger;
using Hunty.Chat.Transverse.Models.Response.Message;

namespace Hunty.Chat.Back.Application.Utilities.Profiles
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<CreateMessageResponse, MessageModel>()
                .ForMember(d => d.Id, s => s.MapFrom(src => src.id))
                .ForPath(d => d.Conversation.Room.Id, s => s.MapFrom(src => src.app_id))
                .ForMember(d => d.DateCreated, s => s.MapFrom(src => src.created_at))
                .ForPath(d => d.Conversation.User.Id, s => s.MapFrom(src => src.created_by.id))
                .ForPath(d => d.Conversation.User.Code, s => s.MapFrom(src => src.created_by.uid))
                .ForPath(d => d.Conversation.User.Name, s => s.MapFrom(src => src.created_by.display_name))
                .ForMember(d => d.Text, s => s.MapFrom(src => src.text))
                .ForMember(d => d.IsFromWebhook, s => s.MapFrom(src => false));

            CreateMap<WebhookMessengerRequest, MessageModel>()
                .ForMember(d => d.Id, s => s.MapFrom(src => src.message.id))
                .ForPath(d => d.Conversation.Room.Id, s => s.MapFrom(src => src.message.app_id))
                .ForMember(d => d.DateCreated, s => s.MapFrom(src => src.message.created_at))
                .ForPath(d => d.Conversation.User.Id, s => s.MapFrom(src => src.actor.id))
                .ForPath(d => d.Conversation.User.Code, s => s.MapFrom(src => src.actor.uid))
                .ForPath(d => d.Conversation.User.Name, s => s.MapFrom(src => src.actor.display_name))
                .ForMember(d => d.IsFromWebhook, s => s.MapFrom(src => true));

            CreateMap<Messages, MessageModel>()
               .ForMember(d => d.Id, s => s.MapFrom(src => src.Id))
               .ForPath(d => d.Conversation.Room.Id, s => s.MapFrom(src => src.Conversation.Id_Room))
               .ForMember(d => d.DateCreated, s => s.MapFrom(src => src.DateCreated))
               .ForPath(d => d.Conversation.User.Id, s => s.MapFrom(src => src.Conversation.Id_User))
               .ForPath(d => d.Conversation.User.Code, s => s.MapFrom(src => src.Conversation.User.Uid))
               .ForPath(d => d.Conversation.User.Name, s => s.MapFrom(src => src.Conversation.User.Name))
               .ForMember(d => d.IsFromWebhook, s => s.MapFrom(src => src.IsFromWebhook));

            CreateMap<MessageModel, Messages>()
              .ForMember(d => d.Id, s => s.MapFrom(src => src.Id))
              .ForPath(d => d.Conversation.Id_Room, s => s.MapFrom(src => src.Conversation.Room.Id))
              .ForPath(d => d.Conversation.Id, s => s.MapFrom(src => src.Conversation.Id))
              .ForPath(d => d.Id_Conversation, s => s.MapFrom(src => src.Conversation.Id))
              .ForMember(d => d.DateCreated, s => s.MapFrom(src => src.DateCreated))
              .ForPath(d => d.Conversation.Id_User, s => s.MapFrom(src => src.Conversation.User.Id))
              .ForPath(d => d.Conversation.User.Id, s => s.MapFrom(src => src.Conversation.User.Id))
              .ForPath(d => d.Conversation.User.Uid, s => s.MapFrom(src => src.Conversation.User.Code))
              .ForPath(d => d.Conversation.User.Name, s => s.MapFrom(src => src.Conversation.User.Name))
              .ForMember(d => d.IsFromWebhook, s => s.MapFrom(src => src.IsFromWebhook));

            CreateMap<MessageModel, MessageResponse>()
               .ForMember(d => d.Id, s => s.MapFrom(src => src.Id))
               .ForMember(d => d.Text, s => s.MapFrom(src => src.Text))
               .ForMember(d => d.DateCreated, s => s.MapFrom(src => src.DateCreated))
               .ForPath(d => d.Conversation.User.Uid, s => s.MapFrom(src => src.Conversation.User.Code))
               .ForPath(d => d.Conversation.User.Name, s => s.MapFrom(src => src.Conversation.User.Name))
               .ForPath(d => d.Conversation.Room.Uid, s => s.MapFrom(src => src.Conversation.Room.Uid))
               .ForPath(d => d.Conversation.Room.Name, s => s.MapFrom(src => src.Conversation.Room.Name))
               .ForMember(d => d.IsFromWebhook, s => s.MapFrom(src => src.IsFromWebhook));

            CreateMap<Messages, MessageResponse>()
              .ForMember(d => d.Id, s => s.MapFrom(src => src.Id))
              .ForMember(d => d.Text, s => s.MapFrom(src => src.Text))
              .ForMember(d => d.DateCreated, s => s.MapFrom(src => src.DateCreated))
              .ForPath(d => d.Conversation.User.Uid, s => s.MapFrom(src => src.Conversation.User.Uid))
              .ForPath(d => d.Conversation.User.Name, s => s.MapFrom(src => src.Conversation.User.Name))
              .ForPath(d => d.Conversation.Room.Uid, s => s.MapFrom(src => src.Conversation.Room.Uid))
              .ForPath(d => d.Conversation.Room.Name, s => s.MapFrom(src => src.Conversation.Room.Name))
              .ForMember(d => d.IsFromWebhook, s => s.MapFrom(src => src.IsFromWebhook));
        }
    }
}
