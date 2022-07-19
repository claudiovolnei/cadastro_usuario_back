using RegistrationUsers.Application.Dto.Dto;
using RegistrationUsers.Domain.Models;

namespace RegistrationUsers.Infrastructure.CrossCutting.Adapter.Interface
{
    public interface IMapperHistoricoEscolar
    {
        void MapperToEntity(HistoricoEscolarDto historicoEscolarDto, HistoricoEscolar historicoEscolar);
        HistoricoEscolarDto MapperToDto(HistoricoEscolar historicoEscolar);
    }
}
