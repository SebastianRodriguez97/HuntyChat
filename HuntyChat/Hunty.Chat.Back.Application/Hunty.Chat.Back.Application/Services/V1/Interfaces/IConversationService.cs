using Hunty.Chat.Back.Application.Models;
using Hunty.Chat.Back.Database.Entities;
using System.Threading.Tasks;

namespace Hunty.Chat.Back.Application.Services.V1.Interfaces
{
    public interface IConversationService
    {
        Task<bool> AddMember(string idRoom, string idUser);
        Task<ConversationModel> GetUserConversation(string codeUser);
        Task<Conversations> GetById(int id);
    }
}
