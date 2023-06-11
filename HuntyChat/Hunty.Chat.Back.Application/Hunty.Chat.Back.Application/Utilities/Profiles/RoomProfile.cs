using AutoMapper;
using Hunty.Chat.Back.Application.Models;
using Hunty.Chat.Back.Application.Models.ExternalChat.Response;
using Hunty.Chat.Back.Database.Entities;
using Hunty.Chat.Transverse.Models.Request.Messenger;

namespace Hunty.Chat.Back.Application.Utilities.Profiles
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<RoomModel, Rooms>()
                .ForMember(d => d.Id, s => s.MapFrom(src => src.Id))
                .ForMember(d => d.Uid, s => s.MapFrom(src => src.Uid))
                .ForMember(d => d.Name, s => s.MapFrom(src => src.Name));

            CreateMap<Rooms, RoomModel>()
                .ForMember(d => d.Id, s => s.MapFrom(src => src.Id))
                .ForMember(d => d.Uid, s => s.MapFrom(src => src.Uid))
                .ForMember(d => d.Name, s => s.MapFrom(src => src.Name));
        }
    }
}
