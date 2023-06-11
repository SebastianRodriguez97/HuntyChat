using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Hunty.Chat.Back.Application.Utilities.Profiles;

namespace Hunty.Chat.Back.API.Installer
{
    public class AutoMapperInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(UserProfile));
            services.AddAutoMapper(typeof(RoomProfile));
            services.AddAutoMapper(typeof(ConversationProfile));
            services.AddAutoMapper(typeof(MessageProfile));
        }
    }
}
