using RegistrationUsers.Application.Dto;
using RegistrationUsers.Application.Interfaces;
using RegistrationUsers.Domain.Core.Interfaces.Services;
using RegistrationUsers.Domain.Models;
using RegistrationUsers.Infrastructure.CrossCutting.Adapter.Interface;

namespace RegistrationUsers.Application.Services
{
    public class ApplicationServiceUsuario : IApplicationServiceUsuario
    {
        private readonly IServiceUsuario _serviceUsuario;
        private readonly IMapperUsuario _mapper;
        public ApplicationServiceUsuario(IServiceUsuario serviceUsuario, IMapperUsuario mapper)
        {
            _serviceUsuario = serviceUsuario;
            _mapper = mapper;
        }
        public void Add(UsuarioDto obj)
        {
            var usuario = new Usuario();
            _mapper.MapperToEntity(obj, usuario);
            _serviceUsuario.Add(usuario);
        }

        public void Dispose()
        {
            _serviceUsuario.Dispose();
        }

        public IEnumerable<UsuarioDto> GetAll()
        {
            var objUsuarios = _serviceUsuario.GetAll();
            return _mapper.MapperToListUsuariosDto(objUsuarios);
        }

        public UsuarioDto? GetById(int id)
        {
            var objUsuario = _serviceUsuario.GetById(id);
            if (objUsuario is null)
                return null;

            return _mapper.MapperToDto(objUsuario);
        }

        public bool Remove(int id)
        {
            var objUsuario = _serviceUsuario.GetById(id);

            if (objUsuario != null)
            {
                _serviceUsuario.Remove(objUsuario);
                return true;
            }

            return false;
        }

        public bool Update(UsuarioDto obj)
        {
            var usuario = _serviceUsuario.GetById(obj.Id.Value);
            if (usuario != null)
            {
                _mapper.MapperToEntity(obj, usuario);
                _serviceUsuario.Update(usuario);
                return true;
            }

            return false;
        }
    }
}
