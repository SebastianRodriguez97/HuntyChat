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
    public class RoomService : IRoomService
    {
        private readonly IMapper _mapper;
        private readonly RoomRepository _roomRepository;
        private readonly RoomExtChat _roomExtChat;

        const String UID_CHAT = "HUNTYCHAT";
        const String NAME_CHAT = "Hunty Chat";

        public RoomService(
            IMapper mapper,
            RoomRepository roomRepository,
            RoomExtChat roomExtChat)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
            _roomExtChat = roomExtChat;
        }

        public async Task<RoomModel> GetMyActiveRoom()
        {
            RoomModel room = new RoomModel()
            {
                Uid = UID_CHAT,
                Name = NAME_CHAT
            };

            InitAPPResponse initAPP = await _roomExtChat.InitRoom(room);

            if (initAPP is null)
                return null;

            Rooms roomRepo = await _roomRepository.GetByCodeAsync(room.Uid);
            if (roomRepo is null)
            {
                room.Id = initAPP.id;
                roomRepo = _mapper.Map<RoomModel, Rooms>(room);
                roomRepo = await _roomRepository.AddAsync(roomRepo);
            }

            return _mapper.Map<Rooms, RoomModel>(roomRepo);
        }
    }
}
