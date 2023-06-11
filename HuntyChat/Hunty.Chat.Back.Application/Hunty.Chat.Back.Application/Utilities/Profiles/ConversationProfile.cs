using AutoMapper;
using Hunty.Chat.Back.Application.Models;
using Hunty.Chat.Back.Database.Entities;

namespace Hunty.Chat.Back.Application.Utilities.Profiles
{
    public class ConversationProfile : Profile
    {
        public ConversationProfile()
        {
            CreateMap<Conversations, ConversationModel>()
                .ForMember(d => d.Id, s => s.MapFrom(src => src.Id))
                .ForMember(d => d.Room, s => s.MapFrom(src => src.Room))
                .ForMember(d => d.User, s => s.MapFrom(src => src.User));

        }
    }
}
