using RegistrationUsers.Application.Dto.Dto;
using RegistrationUsers.Domain.Models;

namespace RegistrationUsers.Infrastructure.CrossCutting.Adapter.Interface
{
    public interface IMapperHistoricoEscolar
    {
        HistoricoEscolar MapperToEntity(HistoricoEscolarDto historicoEscolarDto);
        HistoricoEscolarDto MapperToDto(HistoricoEscolar historicoEscolar);
        void MapperToEntity(HistoricoEscolarDto historicoEscolarDto, ref HistoricoEscolar historicoEscolar);
    }
}
