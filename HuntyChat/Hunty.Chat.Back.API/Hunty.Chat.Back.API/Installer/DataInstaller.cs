using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Hunty.Chat.Back.Application.Repository.Implementations;
using Hunty.Chat.Back.Database.Context;
using Hunty.Chat.Back.Application.Utilities.AppSettingsKeys;

namespace Hunty.Chat.Back.API.Installer
{
    public class DataInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<HuntyChatBackAPIKeys>(configuration.GetSection("WeavyChatPlatformAPI"));

            services.AddDbContext<TPContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<UserRepository>();
            services.AddTransient<RoomRepository>();
            services.AddTransient<ConversationRepository>();
            services.AddTransient<MessageRepository>();
        }
    }
}
