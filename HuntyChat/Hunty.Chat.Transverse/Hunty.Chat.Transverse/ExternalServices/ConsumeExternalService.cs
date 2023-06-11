using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Hunty.Chat.Transverse.Helpers;
using Hunty.Chat.Transverse.Models.Response;
using Hunty.Chat.Transverse.Constants;

namespace Hunty.Chat.Transverse.ExternalServices
{
    public class ConsumeExternalService : IConsumeExternalService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly HttpClient httpClient;
        private readonly ILogger<ConsumeExternalService> logger;

        public ConsumeExternalService(IHttpClientFactory httpClientFactory, ILogger<ConsumeExternalService> logger)
        {
            this.logger = logger;
            this.httpClientFactory = httpClientFactory;
            httpClient = this.httpClientFactory.CreateClient(HttpClientConstants.HuntyChat_API_Client);
        }

        public async Task<T> RestAsync<T>(string url, HttpMethod httpMethod, object content = null, List<KeyValuePair<string, string>> headers = null)
        {
            string response;
            try
            {
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(httpMethod, url);

                if (headers != null)
                    foreach (KeyValuePair<string, string> header in headers)
                        httpRequestMessage.Headers.Add(header.Key, header.Value);

                if (content != null)
                    httpRequestMessage.Content = CreateHttpContent(content);

                HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

                response = await httpResponseMessage.Content.ReadAsStringAsync();

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    response = JsonConvert.SerializeObject(
                        new BaseApiResponseWithData()
                        {
                            Status = httpResponseMessage.StatusCode.ToString(),
                            Message = httpResponseMessage.StatusCode.ToString(),
                            StatusCode = (int)httpResponseMessage.StatusCode,
                            Data = response
                        });
                }
                else
                {
                    response = JsonConvert.SerializeObject(
                        new BaseApiResponse()
                        {
                            Status = httpResponseMessage.StatusCode.ToString(),
                            Message = httpResponseMessage.StatusCode.ToString(),
                            StatusCode = (int)httpResponseMessage.StatusCode
                        });
                }
            }
            catch(Exception e)
            {
                logger.LogError($"{nameof(ConsumeExternalService)}: Internal Server Error {e}");
                response = JsonConvert.SerializeObject(ResponseHelper.SetInternalServerErrorResponse(e.Message));
            }

            logger.LogTrace($"{nameof(ConsumeExternalService)}: {response}");

            return JsonConvert.DeserializeObject<T>(response);
        }

        private static HttpContent CreateHttpContent<T>(T content)
        {
            string jsonContent = JsonConvert.SerializeObject(content);
            return new StringContent(jsonContent, Encoding.UTF8, MediaTypeNames.Application.Json);
        }
    }
}
