using Microsoft.Extensions.DependencyInjection;
using RegistrationUsers.Application.Interfaces;
using RegistrationUsers.Application.Services;
using RegistrationUsers.Domain.Core.Interfaces.Repositorys;
using RegistrationUsers.Domain.Core.Interfaces.Services;
using RegistrationUsers.Domain.Services.Services;
using RegistrationUsers.Infrastructure.CrossCutting.Adapter.Interface;
using RegistrationUsers.Infrastructure.CrossCutting.Adapter.Mappers;
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
            services.AddScoped<IApplicationServiceEscolaridade,ApplicationServiceEscolaridade>();
            services.AddScoped<IApplicationServiceHistoricoEscolar, ApplicationServiceHistoricoEscolar>();
            #endregion

            #region IOC Services
            services.AddScoped<IServiceUsuario,ServiceUsuario>();
            services.AddScoped<IServiceEscolaridade,ServiceEscolaridade>();
            services.AddScoped<IServiceHistoricoEscolar, ServiceHistoricoEscolar>();
            #endregion

            #region IOC Repositorys SQL
            services.AddScoped<IRepositoryUsuario,RepositoryUsuario>();            
            services.AddScoped<IRepositoryEscolaridade,RepositoryEscolaridade>();            
            services.AddScoped<IRepositoryHistoricoEscolar, RepositoryHistoricoEscolar>();            
            #endregion

            #region IOC Mapper
             services.AddScoped<IMapperUsuario, MapperUsuario>();            
             services.AddScoped<IMapperEscolaridade, MapperEscolaridade>();            
             services.AddScoped<IMapperHistoricoEscolar, MapperHistoricoEscolar>();            
            #endregion

            #endregion

        }
    }
}
