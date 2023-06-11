using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hunty.Chat.Front.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<string> GetAccessToken();
    }
}
