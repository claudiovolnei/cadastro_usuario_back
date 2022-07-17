using RegistrationUsers.Application.Dto;
using RegistrationUsers.Application.Interface;
using RegistrationUsers.Application.Interfaces;
using RegistrationUsers.Domain.Core.Interfaces.Services;
using RegistrationUsers.Domain.Models;

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
            var objProdutos = _serviceUsuario.GetAll();
            return _mapper.MapperToListUsuariosDto(objProdutos);
        }

        public UsuarioDto? GetById(int id)
        {
            var objUsuario = _serviceUsuario.GetById(id);
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
            var usuario = _serviceUsuario.GetById(obj.Id);
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
