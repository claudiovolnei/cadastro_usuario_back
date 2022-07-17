using RegistrationUsers.Application.Dto;
using RegistrationUsers.Domain.Models;

namespace RegistrationUsers.Application.Interface
{
   public interface IMapperUsuario
   {
        void MapperToEntity(UsuarioDto usuarioDto, Usuario usuario);
        UsuarioDto MapperToDto(Usuario usuario);
        IEnumerable<UsuarioDto> MapperToListUsuariosDto(IEnumerable<Usuario> usuarios);
   } 
}
    
