using Microsoft.Extensions.DependencyInjection;
using RegistrationUsers.Application.Interfaces;
using RegistrationUsers.Application.Services;
using RegistrationUsers.Domain.Core.Interfaces.Repositorys;
using RegistrationUsers.Domain.Core.Interfaces.Services;
using RegistrationUsers.Domain.Services.Services;
using RegistrationUsers.Infrastructure.Repository.Respositorys;

namespace RegistrationUsers.Infrastructure.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region Registra IOC

            #region IOC Application
            services.AddScoped<IApplicationServiceUsuario,ApplicationServiceUsuario>();
            #endregion

            #region IOC Services
            services.AddScoped<IServiceUsuario,ServiceUsuario>();
            #endregion

            #region IOC Repositorys SQL
            services.AddScoped<IRepositoryUsuario,RepositoryUsuario>();            
            #endregion

            #endregion

        }
    }
}
