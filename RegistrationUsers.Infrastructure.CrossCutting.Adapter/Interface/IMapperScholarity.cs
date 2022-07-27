using RegistrationUsers.Application.Dto.Dto;
using RegistrationUsers.Domain.Models;

namespace RegistrationUsers.Infrastructure.CrossCutting.Adapter.Interface
{
    public interface IMapperScholarity
    {
        IEnumerable<ScholarityDto> MapperToListScholarityDto(IEnumerable<Scholarity> Scholaritys);
        ScholarityDto MapperToDto(Scholarity scholarity);
    }
}
