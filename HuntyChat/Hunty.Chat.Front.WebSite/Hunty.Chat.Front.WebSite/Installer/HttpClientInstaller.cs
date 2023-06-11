using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Security.Authentication;
using Hunty.Chat.Transverse.Constants;
using Hunty.Chat.Transverse.ExternalServices;

namespace Hunty.Chat.Front.WebSite.Installer
{
    public class HttpClientInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient(HttpClientConstants.HuntyChat_API_Client, client =>
            {
                client.BaseAddress = new Uri(configuration.GetSection("HuntyChatBackAPI:BaseRoute").Value);
            }).
            ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler()
            {
                SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls11 | SslProtocols.Tls,
                ClientCertificateOptions = ClientCertificateOption.Automatic,
                PreAuthenticate = true
            });

            services.AddTransient<IConsumeExternalService, ConsumeExternalService>();
        }
    }
}
