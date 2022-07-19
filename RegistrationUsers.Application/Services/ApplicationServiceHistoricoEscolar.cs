using RegistrationUsers.Application.Dto.Dto;
using RegistrationUsers.Application.Interfaces;
using RegistrationUsers.Domain.Core.Interfaces.Services;
using RegistrationUsers.Domain.Models;
using RegistrationUsers.Infrastructure.CrossCutting.Adapter.Interface;

namespace RegistrationUsers.Application.Services
{
    
    public class ApplicationServiceHistoricoEscolar : IApplicationServiceHistoricoEscolar
    {
        private readonly IServiceHistoricoEscolar _serviceHistoricoEscolar;
        private readonly IMapperHistoricoEscolar _mapper;
        public ApplicationServiceHistoricoEscolar(IServiceHistoricoEscolar serviceHistoricoEscolar, IMapperHistoricoEscolar mapper)
        {
            _serviceHistoricoEscolar = serviceHistoricoEscolar;
            _mapper = mapper;
        }

        public void Add(HistoricoEscolarDto obj)
        {
            var historicoEscolar = new HistoricoEscolar();
            _mapper.MapperToEntity(obj, historicoEscolar);
            _serviceHistoricoEscolar.Add(historicoEscolar);
        }

        public void Dispose()
        {
            _serviceHistoricoEscolar.Dispose();
        }

        public HistoricoEscolarDto? GetById(int id)
        {
            var objHistoricoEscolar = _serviceHistoricoEscolar.GetById(id);
            if (objHistoricoEscolar is null)
                return null;

            return _mapper.MapperToDto(objHistoricoEscolar);
        }

        public bool Remove(int id)
        {
            var objHistoricoEscolar = _serviceHistoricoEscolar.GetById(id);

            if (objHistoricoEscolar != null)
            {
                _serviceHistoricoEscolar.Remove(objHistoricoEscolar);
                return true;
            }

            return false;
        }

        public bool Update(HistoricoEscolarDto obj)
        {
            var historicoEscolar = _serviceHistoricoEscolar.GetById(obj.Id.Value);
            if (historicoEscolar != null)
            {
                _mapper.MapperToEntity(obj, historicoEscolar);
                _serviceHistoricoEscolar.Update(historicoEscolar);
                return true;
            }

            return false;
        }
    }
}
