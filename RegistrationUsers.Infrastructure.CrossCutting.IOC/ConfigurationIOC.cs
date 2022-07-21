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
            services.AddScoped<IApplicationServiceUser,ApplicationServiceUser>();
            services.AddScoped<IApplicationServiceScholarity,ApplicationServiceScholarity>();
            services.AddScoped<IApplicationServiceSchoolRecords, ApplicationServiceSchoolRecords>();
            #endregion

            #region IOC Services
            services.AddScoped<IServiceUser,ServiceUser>();
            services.AddScoped<IServiceScholarity,ServiceScholarity>();
            services.AddScoped<IServiceSchoolRecords, ServiceSchoolRecords>();
            #endregion

            #region IOC Repositorys SQL
            services.AddScoped<IRepositoryUser,RepositoryUser>();            
            services.AddScoped<IRepositoryScholarity,RepositoryScholarity>();            
            services.AddScoped<IRepositorySchoolRecords, RepositorySchoolRecords>();            
            #endregion

            #region IOC Mapper
             services.AddScoped<IMapperUser, MapperUser>();            
             services.AddScoped<IMapperScholarity, MapperScholarity>();            
             services.AddScoped<IMapperSchoolRecords, MapperSchoolRecords>();            
            #endregion

            #endregion

        }
    }
}
