using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Threading.Tasks;
using Hunty.Chat.Front.Application.Repository.Interfaces;
using Hunty.Chat.Front.Application.Utility.AppSettingsKeys;
using Hunty.Chat.Transverse.ExternalServices;
using Hunty.Chat.Transverse.Models.Response;

namespace Hunty.Chat.Front.Application.Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly IConsumeExternalService _consumeExternalService;
        private readonly IOptions<HuntyChatFrontAPIKeys> _tpFrontApiKeys;

        public UserRepository(IConsumeExternalService consumeExternalService, IOptions<HuntyChatFrontAPIKeys> tpFrontApiKeys)
        {
            _consumeExternalService = consumeExternalService;
            _tpFrontApiKeys = tpFrontApiKeys;
        }

        public async Task<BaseApiResponseWithData> GetAccessToken()
        {
            string url = _tpFrontApiKeys.Value.GetTokenAccess;
            BaseApiResponseWithData baseApiResponse = await _consumeExternalService.RestAsync<BaseApiResponseWithData>(url, HttpMethod.Get);

            return baseApiResponse;
        }
    }
}
