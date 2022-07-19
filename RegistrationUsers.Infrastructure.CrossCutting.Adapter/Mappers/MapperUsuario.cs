using RegistrationUsers.Application.Dto;
using RegistrationUsers.Domain.Models;
using RegistrationUsers.Infrastructure.CrossCutting.Adapter.Interface;

namespace RegistrationUsers.Infrastructure.CrossCutting.Adapter.Mappers
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
            usuario.Id = usuarioDto.Id == null ? 0 : usuarioDto.Id.Value;
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
