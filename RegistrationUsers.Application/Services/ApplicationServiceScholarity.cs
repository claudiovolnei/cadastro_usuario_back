using RegistrationUsers.Application.Dto.Dto;
using RegistrationUsers.Application.Interfaces;
using RegistrationUsers.Domain.Core.Interfaces.Services;
using RegistrationUsers.Infrastructure.CrossCutting.Adapter.Interface;

namespace RegistrationUsers.Application.Services
{
    public class ApplicationServiceScholarity : IApplicationServiceScholarity
    {
        private readonly IServiceScholarity _serviceScholarity;
        private readonly IMapperScholarity _mapper;
        public ApplicationServiceScholarity(IServiceScholarity serviceScholarity, IMapperScholarity mapper)
        {
            _serviceScholarity = serviceScholarity;
            _mapper = mapper;
        }
        public void Dispose()
        {
            _serviceScholarity.Dispose();
        }

        public async Task<IEnumerable<ScholarityDto>> GetAll()
        {
            var scholarities = await _serviceScholarity.GetAll();
            return _mapper.MapperToListScholarityDto(scholarities);
        }
    }
}
