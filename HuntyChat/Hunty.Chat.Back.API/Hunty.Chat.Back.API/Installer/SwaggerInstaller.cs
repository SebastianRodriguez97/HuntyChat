using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using Hunty.Chat.Back.API.Utility.Constants;

namespace Hunty.Chat.Back.API.Installer
{
    public class SwaggerInstaller : IInstaller
    {

        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(SwaggerConstants.Version, new OpenApiInfo
                {
                    Title = string.Format(SwaggerConstants.Title, SwaggerConstants.Version),
                    Version = SwaggerConstants.Version,
                    Description = SwaggerConstants.Descripcion,
                    Contact = new OpenApiContact
                    {
                        Name = SwaggerConstants.NameContact,
                        Email = SwaggerConstants.EmailContact,
                        Url = new Uri(SwaggerConstants.UrlContact),
                    }
                });
            });
        }
    }
}
