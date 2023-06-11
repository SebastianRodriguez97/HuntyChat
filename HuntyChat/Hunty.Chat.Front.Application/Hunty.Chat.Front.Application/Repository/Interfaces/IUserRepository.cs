using Hunty.Chat.Transverse.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hunty.Chat.Front.Application.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<BaseApiResponseWithData> GetAccessToken();
    }
}
