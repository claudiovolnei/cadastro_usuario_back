using RegistrationUsers.Application.Dto.Dto;
using RegistrationUsers.Domain.Models;
using RegistrationUsers.Infrastructure.CrossCutting.Adapter.Interface;

namespace RegistrationUsers.Infrastructure.CrossCutting.Adapter.Mappers
{
    public class MapperScholarity : IMapperScholarity
    {
        public IEnumerable<ScholarityDto> MapperToListScholarityDto(IEnumerable<Scholarity> scholaritys)
        {
            var scholaritysList = new List<ScholarityDto>();
            foreach (var scholarity in scholaritys)
            {
                var scholaritysEntity = new ScholarityDto
                {
                    Id = scholarity.Id,
                    Description = scholarity.Description
                };

                scholaritysList.Add(scholaritysEntity);
            }

            return scholaritysList;
        }
    }
}
