using RegistrationUsers.Application.Dto;

namespace RegistrationUsers.Application.Interfaces
{
    public interface IApplicationServiceUsuario
    {
        void Add(UsuarioDto obj);

        UsuarioDto? GetById(int id);

        IEnumerable<UsuarioDto> GetAll();

        bool Update(UsuarioDto obj);

        bool Remove(int id);

        void Dispose();
    }
}
