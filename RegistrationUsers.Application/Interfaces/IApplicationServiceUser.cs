using Microsoft.AspNetCore.Http;
using RegistrationUsers.Application.Dto.Dto;

namespace RegistrationUsers.Application.Interfaces
{
    public interface IApplicationServiceUser
    {
        Task<UserDto> Add(UserDto obj);

        Task<UserDto>? GetById(int id);
        Task<UserDto> GetUserAsync(int id);

        Task<IEnumerable<UserDto>> GetAll();

        Task<bool> Update(UserDto obj);

        Task<bool> Remove(int id);

        void Dispose();
    }
}
