using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using RegistrationUsers.Application.Dto.Dto;
using RegistrationUsers.Application.Dto.Types;
using RegistrationUsers.Application.Interfaces;
using RegistrationUsers.Domain.Core.Interfaces.Services;
using RegistrationUsers.Infrastructure.CrossCutting.Adapter.Interface;

namespace RegistrationUsers.Application.Services
{
    
    public class ApplicationServiceSchoolRecords : IApplicationServiceSchoolRecords
    {
        private readonly IServiceSchoolRecords _serviceSchoolRecords;
        private readonly IMapperSchoolRecords _mapper;
        private readonly IConfiguration _configuration;
        public ApplicationServiceSchoolRecords(IServiceSchoolRecords serviceSchoolRecords, IMapperSchoolRecords mapper, IConfiguration configuration)
        {
            _serviceSchoolRecords = serviceSchoolRecords;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<SchoolRecordsDto> Add(IFormFile file)
        {
            var caminho = await UploadFile(file);

            if (caminho == null)
                throw new Exception("Erro ao armazenar histórico.");

            var SchoolRecordsDto = new SchoolRecordsDto
            {
                Name = file.FileName,
                Format = file.ContentType,
                Path = caminho
            };
            var SchoolRecords = await _serviceSchoolRecords.Add(_mapper.MapperToEntity(SchoolRecordsDto));            
            return _mapper.MapperToDto(SchoolRecords);
        }

        public void Dispose()
        {
            _serviceSchoolRecords.Dispose();
        }

        public async Task<SchoolRecordsDto> GetById(int id)
        {
            var objSchoolRecords = await _serviceSchoolRecords.GetById(id);

            return _mapper.MapperToDto(objSchoolRecords);
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
                    using (var fileStream = new FileStream(Path.Combine(pathUpload, guid  + "_" + file.FileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    return pathUpload + guid + "_" + file.FileName;
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
