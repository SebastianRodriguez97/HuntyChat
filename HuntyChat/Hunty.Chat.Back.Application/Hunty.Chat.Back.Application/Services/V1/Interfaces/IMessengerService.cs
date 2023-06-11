using Hunty.Chat.Transverse.Models.Request.Messenger;
using System.Threading.Tasks;

namespace Hunty.Chat.Back.Application.Services.V1.Interfaces
{
    public interface IMessengerService
    {
        Task<object> InBoundMessages(WebhookMessengerRequest webhookMessengerRequest);
        Task<object> OutBoundMessages(SendMessageMessengerRequest sendMessageMessengerRequest);
        Task<object> GetAllMessagesFromWebhook();
    }
}
