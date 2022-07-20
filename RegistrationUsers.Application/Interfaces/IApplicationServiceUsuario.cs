using Microsoft.AspNetCore.Http;
using RegistrationUsers.Application.Dto;

namespace RegistrationUsers.Application.Interfaces
{
    public interface IApplicationServiceUsuario
    {
        Task<UsuarioDto> Add(UsuarioDto obj);

        Task<UsuarioDto>? GetById(int id);

        Task<IEnumerable<UsuarioDto>> GetAll();

        Task<bool> Update(UsuarioDto obj);

        Task<bool> Remove(int id);

        void Dispose();
    }
}
