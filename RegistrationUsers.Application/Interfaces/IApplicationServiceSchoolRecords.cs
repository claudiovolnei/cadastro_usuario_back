using Microsoft.AspNetCore.Http;
using RegistrationUsers.Application.Dto.Dto;

namespace RegistrationUsers.Application.Interfaces
{
    public interface IApplicationServiceSchoolRecords
    {
        Task<SchoolRecordsDto> Add(IFormFile file);

        Task<SchoolRecordsDto>? GetById(int id);

        Task<FileDto> DownloadFile(SchoolRecordsDto schoolRecordsDto);


        void Dispose();
    }
}
