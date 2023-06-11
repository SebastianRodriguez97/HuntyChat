using Hunty.Chat.Back.Application.Models;
using System.Threading.Tasks;

namespace Hunty.Chat.Back.Application.Services.V1.Interfaces
{
    public interface IUserService
    {
        Task<UserModel> Get(string codeUser);
        Task<UserModel> Create(string codeUser);
        Task<UserModel> Update(UserModel userModel);
        Task<UserModel> GetAccessToken(UserModel userModel);
        Task<UserModel> GetUserWithAuthAlive(string codeUser);
    }
}
