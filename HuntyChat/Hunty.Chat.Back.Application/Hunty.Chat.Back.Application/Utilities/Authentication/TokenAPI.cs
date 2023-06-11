using Hunty.Chat.Back.Application.Utilities.AppSettingsKeys;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace Hunty.Chat.Back.Application.Utilities.Authentication
{
    public class TokenAPI
    {
        private readonly IOptions<HuntyChatBackAPIKeys> _tpBackApiKeys;

        public TokenAPI(IOptions<HuntyChatBackAPIKeys> tpBackApiKeys)
        {
            _tpBackApiKeys = tpBackApiKeys;
        }

        public List<KeyValuePair<string, string>> GetAPIKeyHeader()
        {
            return new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("Authorization", "Bearer " + _tpBackApiKeys.Value.APIKey)
            };
        }

        public List<KeyValuePair<string, string>> GetAccessTokenHeader(string accessToken)
        {
            return new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("Authorization", "Bearer " + accessToken)
            };
        }
    }
}
