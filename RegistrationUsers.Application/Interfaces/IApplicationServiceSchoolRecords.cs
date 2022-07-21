using Microsoft.AspNetCore.Http;
using RegistrationUsers.Application.Dto.Dto;

namespace RegistrationUsers.Application.Interfaces
{
    public interface IApplicationServiceSchoolRecords
    {
        Task<SchoolRecordsDto> Add(IFormFile file);

        Task<SchoolRecordsDto>? GetById(int id);

        Task<bool> Update(SchoolRecordsDto obj);

        Task<bool> Remove(int id);

        void Dispose();
    }
}
