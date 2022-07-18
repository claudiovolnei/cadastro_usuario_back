using RegistrationUsers.Application.Dto.Dto;
using RegistrationUsers.Application.Interfaces;
using RegistrationUsers.Domain.Core.Interfaces.Services;
using RegistrationUsers.Infrastructure.CrossCutting.Adapter.Interface;

namespace RegistrationUsers.Application.Services
{
    public class ApplicationServiceEscolaridade : IApplicationServiceEscolaridade
    {
        private readonly IServiceEscolaridade _serviceEscolaridade;
        private readonly IMapperEscolaridade _mapper;
        public ApplicationServiceEscolaridade(IServiceEscolaridade serviceEscolaridade, IMapperEscolaridade mapper)
        {
            _serviceEscolaridade = serviceEscolaridade;
            _mapper = mapper;
        }
        public void Dispose()
        {
            _serviceEscolaridade.Dispose();
        }

        public IEnumerable<EscolaridadeDto> GetAll()
        {
            var escolaridades = _serviceEscolaridade.GetAll();
            return _mapper.MapperToListEscolaridadeDto(escolaridades);
        }
    }
}
