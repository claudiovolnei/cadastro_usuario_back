using RegistrationUsers.Application.Dto;
using RegistrationUsers.Domain.Models;

namespace RegistrationUsers.Infrastructure.CrossCutting.Adapter.Interface
{
   public interface IMapperUsuario
   {
        void MapperToEntity(UsuarioDto usuarioDto, ref Usuario usuario);
        Usuario MapperToEntity(UsuarioDto usuarioDto);
        UsuarioDto MapperToDto(Usuario usuario);
        IEnumerable<UsuarioDto> MapperToListUsuariosDto(IEnumerable<Usuario> usuarios);
   } 
}
    
