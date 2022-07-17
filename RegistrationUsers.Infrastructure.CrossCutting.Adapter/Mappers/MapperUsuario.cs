using RegistrationUsers.Application.Dto;
using RegistrationUsers.Application.Interface;
using RegistrationUsers.Domain.Models;

namespace RegistrationUsers.Application.Mappers
{
    public class MapperUsuario : IMapperUsuario
    {
        public UsuarioDto MapperToDto(Usuario usuario)
        {
            return new UsuarioDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                DataNascimento = usuario.DataNascimento,
                Email = usuario.Email,
                EscolaridadeId = usuario.EscolaridadeId,
                HistoricoEscolarId = usuario.HistoricoEscolarId,
                Sobrenome = usuario.Sobrenome
            };
        }

        public void MapperToEntity(UsuarioDto usuarioDto, Usuario usuario)
        {
            usuario.Id = usuarioDto.Id;
            usuario.Nome = usuarioDto.Nome;
            usuario.DataNascimento = usuarioDto.DataNascimento;
            usuario.Email = usuarioDto.Email;
            usuario.EscolaridadeId = usuarioDto.EscolaridadeId;
            usuario.HistoricoEscolarId = usuarioDto.HistoricoEscolarId;
            usuario.Sobrenome = usuarioDto.Sobrenome;            
        }

        public IEnumerable<UsuarioDto> MapperToListUsuariosDto(IEnumerable<Usuario> usuarios)
        {
            var usuarioList = new List<UsuarioDto>();
            foreach (var usuario in usuarios)
            {
                var usuarioEntity = new UsuarioDto
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    DataNascimento = usuario.DataNascimento,
                    Email = usuario.Email,
                    EscolaridadeId = usuario.EscolaridadeId,
                    HistoricoEscolarId = usuario.HistoricoEscolarId,
                    Sobrenome = usuario.Sobrenome
                };

                usuarioList.Add(usuarioEntity);
            }

            return usuarioList;
        }
    }
}
