using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Hunty.Chat.Front.Application.Repository.Implementations;
using Hunty.Chat.Front.Application.Repository.Interfaces;
using Hunty.Chat.Front.Application.Services.Implementations;
using Hunty.Chat.Front.Application.Services.Interfaces;
using Hunty.Chat.Front.Application.Utility.AppSettingsKeys;

namespace Hunty.Chat.Front.WebSite.Installer
{
    public class ApplicationInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<HuntyChatFrontAPIKeys>(configuration.GetSection("HuntyChatBackAPI"));

            services.AddScoped<IUserService, UserService>();

            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}
