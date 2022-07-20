using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using RegistrationUsers.Application.Dto.Dto;
using RegistrationUsers.Application.Interfaces;
using RegistrationUsers.Domain.Core.Interfaces.Services;
using RegistrationUsers.Infrastructure.CrossCutting.Adapter.Interface;

namespace RegistrationUsers.Application.Services
{
    
    public class ApplicationServiceHistoricoEscolar : IApplicationServiceHistoricoEscolar
    {
        private readonly IServiceHistoricoEscolar _serviceHistoricoEscolar;
        private readonly IMapperHistoricoEscolar _mapper;
        private readonly IConfiguration _configuration;
        public ApplicationServiceHistoricoEscolar(IServiceHistoricoEscolar serviceHistoricoEscolar, IMapperHistoricoEscolar mapper, IConfiguration configuration)
        {
            _serviceHistoricoEscolar = serviceHistoricoEscolar;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<HistoricoEscolarDto> Add(IFormFile file)
        {
            var caminho = await UploadFile(file);

            if (caminho == null)
                throw new Exception("Erro ao armazenar histórico.");

            var historicoEscolarDto = new HistoricoEscolarDto
            {
                Nome = file.FileName,
                Formato = file.ContentType,
                Caminho = caminho
            };
            var historicoEscolar = await _serviceHistoricoEscolar.Add(_mapper.MapperToEntity(historicoEscolarDto));            
            return _mapper.MapperToDto(historicoEscolar);
        }

        public void Dispose()
        {
            _serviceHistoricoEscolar.Dispose();
        }

        public async Task<HistoricoEscolarDto> GetById(int id)
        {
            var objHistoricoEscolar = await _serviceHistoricoEscolar.GetById(id);

            return _mapper.MapperToDto(objHistoricoEscolar);
        }

        public async Task<bool> Remove(int id)
        {
            var objHistoricoEscolar = await _serviceHistoricoEscolar.GetById(id);

            if (objHistoricoEscolar != null)
            {
                await _serviceHistoricoEscolar.Remove(objHistoricoEscolar);
                return true;
            }

            return false;
        }

        public async Task<bool> Update(HistoricoEscolarDto obj)
        {
            var historicoEscolar = await _serviceHistoricoEscolar.GetById(obj.Id.Value);
            if (historicoEscolar != null)
            {
                _mapper.MapperToEntity(obj, ref historicoEscolar);
                await _serviceHistoricoEscolar.Update(historicoEscolar);
                return true;
            }

            return false;
        }

        private async Task<string> UploadFile(IFormFile file)
        {
            var guid = Guid.NewGuid();
            var pathUpload = _configuration["PathFiles:Path"];
            if (pathUpload == null)
                return null;

            try
            {
                if (file.Length > 0)
                {
                    if (!Directory.Exists(pathUpload))
                    {
                        Directory.CreateDirectory(pathUpload);
                    }
                    using (var fileStream = new FileStream(Path.Combine(pathUpload, guid  + file.FileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    return pathUpload + guid  + file.FileName;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("File Copy Failed", ex);
            }
        }
    }
}
