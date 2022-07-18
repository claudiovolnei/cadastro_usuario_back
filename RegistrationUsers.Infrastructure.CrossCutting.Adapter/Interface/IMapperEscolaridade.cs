using RegistrationUsers.Application.Dto.Dto;
using RegistrationUsers.Domain.Models;

namespace RegistrationUsers.Infrastructure.CrossCutting.Adapter.Interface
{
    public interface IMapperEscolaridade
    {
        IEnumerable<EscolaridadeDto> MapperToListEscolaridadeDto(IEnumerable<Escolaridade> escolaridades);
    }
}
