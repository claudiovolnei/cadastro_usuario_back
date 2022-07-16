using RegistrationUsers.Application.Dto;

namespace RegistrationUsers.Application.Interfaces
{
    public interface IApplicationServiceUsuario
    {
        void Add(UsuarioDto obj);

        UsuarioDto GetById(int id);

        IEnumerable<UsuarioDto> GetAll();

        void Update(UsuarioDto obj);

        void Remove(UsuarioDto obj);

        void Dispose();
    }
}
