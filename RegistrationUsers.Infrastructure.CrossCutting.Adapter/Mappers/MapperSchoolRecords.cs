using RegistrationUsers.Application.Dto.Dto;
using RegistrationUsers.Domain.Models;
using RegistrationUsers.Infrastructure.CrossCutting.Adapter.Interface;

namespace RegistrationUsers.Infrastructure.CrossCutting.Adapter.Mappers
{
    public class MapperSchoolRecords : IMapperSchoolRecords
    {
        public SchoolRecordsDto MapperToDto(SchoolRecords schoolRecords)
        {
            return new SchoolRecordsDto
            {
                Id = schoolRecords.Id,
                Name = schoolRecords.Name,
                Format = schoolRecords.Format,
                Path = schoolRecords.Path
            };
        }

        public SchoolRecords MapperToEntity(SchoolRecordsDto schoolRecordsDto)
        {
            return new SchoolRecords
            {
                Id = schoolRecordsDto.Id == null ? 0 : schoolRecordsDto.Id.Value,
                Name = schoolRecordsDto.Name,
                Format = schoolRecordsDto.Format,
                Path = schoolRecordsDto.Path,
            };
        }
        
        public void MapperToEntity(SchoolRecordsDto schoolRecordsDto, ref SchoolRecords schoolRecords)
        {
            schoolRecords.Id = schoolRecordsDto.Id == null ? 0 : schoolRecordsDto.Id.Value;
            schoolRecords.Name = schoolRecordsDto.Name;
            schoolRecords.Format = schoolRecordsDto.Format;
            schoolRecords.Path = schoolRecordsDto.Path;

        }
    }
}
