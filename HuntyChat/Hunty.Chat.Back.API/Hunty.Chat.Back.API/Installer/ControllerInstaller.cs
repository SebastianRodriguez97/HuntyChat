using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Hunty.Chat.Back.API.Utility.ActionFilters;
using Hunty.Chat.Back.Application.Services.V1.Implementations;
using Hunty.Chat.Back.Application.Services.V1.Interfaces;
using Hunty.Chat.Back.Application.Utilities.Authentication;
using Hunty.Chat.Back.Application.ExternalChat;

namespace Hunty.Chat.Back.API.Installer
{
    public class ControllerInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(FluentValidationActionFilter));
            })
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddScoped<IMessengerService, MessengerService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IConversationService, ConversationService>();

            services.AddScoped<TokenAPI>();

            services.AddScoped<UserExtChat>();
            services.AddScoped<ConversationExtChat>();
            services.AddScoped<MessengerExtChat>();
            services.AddScoped<RoomExtChat>();
        }
    }
}
