using AutoMapper;
using RegistrationUsers.Application.Dto;
using RegistrationUsers.Application.Interfaces;
using RegistrationUsers.Domain.Core.Interfaces.Services;
using RegistrationUsers.Domain.Models;

namespace RegistrationUsers.Application.Services
{
    public class ApplicationServiceUsuario : IApplicationServiceUsuario
    {
        private readonly IServiceUsuario _serviceUsuario;
        private readonly IMapper _mapper;
        public ApplicationServiceUsuario(IServiceUsuario serviceUsuario, IMapper mapper)
        {
            _serviceUsuario = serviceUsuario;
            _mapper = mapper;
        }
        public void Add(UsuarioDto obj)
        {
            var objCliente = _mapper.Map<Usuario>(obj);
            _serviceUsuario.Add(objCliente);
        }

        public void Dispose()
        {
            _serviceUsuario.Dispose();
        }

        public IEnumerable<UsuarioDto> GetAll()
        {
            var objProdutos = _serviceUsuario.GetAll();
            return _mapper.Map<IEnumerable<UsuarioDto>>(objProdutos);
        }

        public UsuarioDto GetById(int id)
        {
            var objcliente = _serviceUsuario.GetById(id);
            return _mapper.Map<UsuarioDto>(objcliente);
        }

        public void Remove(UsuarioDto obj)
        {
            var objCliente = _mapper.Map<Usuario>(obj);
            _serviceUsuario.Remove(objCliente);
        }

        public void Update(UsuarioDto obj)
        {
            var objCliente = _mapper.Map<Usuario>(obj);
            _serviceUsuario.Update(objCliente);
        }
    }
}
