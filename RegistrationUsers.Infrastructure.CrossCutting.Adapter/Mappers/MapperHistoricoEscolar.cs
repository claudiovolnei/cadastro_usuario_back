using RegistrationUsers.Application.Dto.Dto;
using RegistrationUsers.Domain.Models;
using RegistrationUsers.Infrastructure.CrossCutting.Adapter.Interface;

namespace RegistrationUsers.Infrastructure.CrossCutting.Adapter.Mappers
{
    public class MapperHistoricoEscolar : IMapperHistoricoEscolar
    {
        public HistoricoEscolarDto MapperToDto(HistoricoEscolar historicoEscolar)
        {
            return new HistoricoEscolarDto
            {
                Id = historicoEscolar.Id,
                Nome = historicoEscolar.Nome,
                Formato = historicoEscolar.Formato,
                Caminho = historicoEscolar.Caminho
            };
        }

        public void MapperToEntity(HistoricoEscolarDto historicoEscolarDto, HistoricoEscolar historicoEscolar)
        {
            historicoEscolar.Id = historicoEscolarDto.Id == null? 0 : historicoEscolarDto.Id.Value,
            historicoEscolar.Nome = historicoEscolarDto.Nome;
            historicoEscolar.Formato = historicoEscolarDto.Formato;
            historicoEscolar.Caminho = historicoEscolarDto.Caminho;
        }
    }
}
