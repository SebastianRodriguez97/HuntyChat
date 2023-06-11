using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Hunty.Chat.Back.API.ApiRoutes.V1;
using Hunty.Chat.Back.Application.Services.V1.Interfaces;
using Hunty.Chat.Transverse.Models.Request.Messenger;
using System.Text.Json;

namespace Hunty.Chat.Back.API.Controllers.V1
{
    [ApiController]
    public class MessengerController : ControllerBase
    {
        private readonly IMessengerService _messengerService;

        public MessengerController(IMessengerService messengerService)
        {
            _messengerService = messengerService;
        }

        [HttpPost(ApiRoutesV1.Message.MessageBase)]
        public async Task<IActionResult> InOutBoundMessages([FromBody] JsonElement objectRequest)
        {
            WebhookMessengerRequest webhookMessengerRequest;
            SendMessageMessengerRequest sendMessageMessengerRequest;
            string jsontRequest = objectRequest.GetRawText();

            webhookMessengerRequest = JsonSerializer.Deserialize<WebhookMessengerRequest>(jsontRequest);
            if (webhookMessengerRequest?.action != null)
                return Ok(await _messengerService.InBoundMessages(webhookMessengerRequest));

            sendMessageMessengerRequest = JsonSerializer.Deserialize<SendMessageMessengerRequest>(jsontRequest);
            return Ok(await _messengerService.OutBoundMessages(sendMessageMessengerRequest));
        }

        [HttpGet(ApiRoutesV1.Message.MessageBase)]
        public async Task<IActionResult> GetAllMessagesFromWebhook()
        {
            return Ok(await _messengerService.GetAllMessagesFromWebhook());
        }
    }
}
