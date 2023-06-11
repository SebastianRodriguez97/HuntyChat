using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hunty.Chat.Front.Application.Utility.ExternalServices
{
    public interface IConsumeExternalService
    {
        Task<T> RestAsync<T>(string url, HttpMethod httpMethod, object content = null, List<KeyValuePair<string, string>> headers = null);
    }
}
