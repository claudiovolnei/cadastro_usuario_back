using RegistrationUsers.Application.Dto.Dto;
using RegistrationUsers.Domain.Models;
using RegistrationUsers.Infrastructure.CrossCutting.Adapter.Interface;

namespace RegistrationUsers.Infrastructure.CrossCutting.Adapter.Mappers
{
    public class MapperEscolaridade : IMapperEscolaridade
    {
        public IEnumerable<EscolaridadeDto> MapperToListEscolaridadeDto(IEnumerable<Escolaridade> escolaridades)
        {
            var escolaridadeList = new List<EscolaridadeDto>();
            foreach (var usuario in escolaridades)
            {
                var escolaridadeEntity = new EscolaridadeDto
                {
                    Id = usuario.Id,
                    Descricao = usuario.Descricao
                };

                escolaridadeList.Add(escolaridadeEntity);
            }

            return escolaridadeList;
        }
    }
}
