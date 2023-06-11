using AutoMapper;
using Hunty.Chat.Back.Application.Models;
using Hunty.Chat.Back.Application.Models.ExternalChat.Response;
using Hunty.Chat.Back.Database.Entities;
using Hunty.Chat.Transverse.Models.Request.Messenger;

namespace Hunty.Chat.Back.Application.Utilities.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserModel, Users>()
                .ForMember(d => d.Id, s => s.MapFrom(src => src.Id))
                .ForMember(d => d.Uid, s => s.MapFrom(src => src.Code))
                .ForMember(d => d.Name, s => s.MapFrom(src => src.Name))
                .ForMember(d => d.AccessToken, s => s.MapFrom(src => src.AccessToken))
                .ForMember(d => d.ExpirationToken, s => s.MapFrom(src => src.ExpiredDate));

            CreateMap<Users, UserModel>()
             .ForMember(d => d.Id, s => s.MapFrom(src => src.Id))
             .ForMember(d => d.Code, s => s.MapFrom(src => src.Uid))
             .ForMember(d => d.Name, s => s.MapFrom(src => src.Name))
             .ForMember(d => d.AccessToken, s => s.MapFrom(src => src.AccessToken))
             .ForMember(d => d.ExpiredDate, s => s.MapFrom(src => src.ExpirationToken));

            CreateMap<GetUserResponse, Users>()
             .ForMember(d => d.Id, s => s.MapFrom(src => src.id))
             .ForMember(d => d.Uid, s => s.MapFrom(src => src.uid))
             .ForMember(d => d.Name, s => s.MapFrom(src => src.display_name));
        }
    }
}
