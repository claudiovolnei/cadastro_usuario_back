using Microsoft.AspNetCore.Http;
using RegistrationUsers.Application.Dto.Dto;

namespace RegistrationUsers.Application.Interfaces
{
    public interface IApplicationServiceSchoolRecords
    {
        Task<SchoolRecordsDto> Add(IFormFile file);

        Task<SchoolRecordsDto>? GetById(int id);

        void Dispose();
    }
}
