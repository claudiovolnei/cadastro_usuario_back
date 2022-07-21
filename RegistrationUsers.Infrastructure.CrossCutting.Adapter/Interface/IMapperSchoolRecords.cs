using RegistrationUsers.Application.Dto.Dto;
using RegistrationUsers.Domain.Models;

namespace RegistrationUsers.Infrastructure.CrossCutting.Adapter.Interface
{
    public interface IMapperSchoolRecords
    {
        SchoolRecords MapperToEntity(SchoolRecordsDto schoolRecordsDto);
        SchoolRecordsDto MapperToDto(SchoolRecords schoolRecords);
        void MapperToEntity(SchoolRecordsDto schoolRecordsDto, ref SchoolRecords schoolRecords);
    }
}
