using Hunty.Chat.Back.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hunty.Chat.Back.Application.Services.V1.Interfaces
{
    public interface IRoomService
    {
        Task<RoomModel> GetMyActiveRoom();
    }
}
