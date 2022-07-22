using Microsoft.AspNetCore.Http;
using RegistrationUsers.Application.Dto.Dto;
using RegistrationUsers.Application.Dto.Types;
using RegistrationUsers.Application.Interfaces;
using RegistrationUsers.Domain.Core.Interfaces.Services;
using RegistrationUsers.Infrastructure.CrossCutting.Adapter.Interface;

namespace RegistrationUsers.Application.Services
{
    public class ApplicationServiceUser : IApplicationServiceUser
    {
        private readonly IServiceUser _serviceUser;
        private readonly IApplicationServiceSchoolRecords _aplicationServiceSchoolRecords;
        private readonly IMapperUser _mapper;
        public ApplicationServiceUser(IServiceUser serviceUser, IMapperUser mapper, IApplicationServiceSchoolRecords aplicationServiceSchoolRecords)
        {
            _serviceUser = serviceUser;
            _mapper = mapper;
            _aplicationServiceSchoolRecords = aplicationServiceSchoolRecords;
        }
        public async Task<UserDto> Add(UserDto obj)
        {
            try
            {                
                var schoolRecords = await SaveSchoolRecords(obj.File);
                if (schoolRecords == null)
                    throw new Exception("Erro ao salvar arquivo.");

                obj.SchoolRecords = schoolRecords;
                var User = _mapper.MapperToEntity(obj);
                User = await _serviceUser.Add(User);
                return _mapper.MapperToDto(User);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public void Dispose()
        {
            _serviceUser.Dispose();
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var objUsers = await _serviceUser.GetAll();
            return _mapper.MapperToListUserDto(objUsers);
        }

        public async Task<UserDto>? GetById(int id)
        {
            var objUser = await _serviceUser.GetById(id);
            return _mapper.MapperToDto(objUser);
        }
        
        public async Task<UserDto> GetUserAsync(int id)
        {
            var objUser = await _serviceUser.GetUserAsync(id);
            return _mapper.MapperToDto(objUser);
        }

        public async Task<bool> Remove(int id)
        {
            var objUser = await _serviceUser.GetById(id);

            if (objUser != null)
            {
                await _serviceUser.Remove(objUser);
                return true;
            }

            return false;
        }

        public async Task<bool> Update(UserDto obj)
        {
            try
            {
                var schoolRecords = await SaveSchoolRecords(obj.File);
                if (schoolRecords == null)
                    throw new Exception("Erro ao salvar arquivo.");

                var User = await _serviceUser.GetUserAsync(obj.Id.Value);
                if (User != null)
                {
                    _mapper.MapperToEntity(obj, ref User);
                    await _serviceUser.Update(User);
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        private async Task<SchoolRecordsDto> SaveSchoolRecords(IFormFile file)
        {
            if (!MimeTypes.GetMimeTypes().Values.Contains(file.ContentType))
                throw new Exception($"Formato de arquivo inválido, somente {MimeTypes.GetMimeTypes().Keys} ");

            return await _aplicationServiceSchoolRecords.Add(file);
        }

       

        
    }
}
