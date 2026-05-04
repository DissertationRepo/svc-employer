using AutoMapper;
using EmployerService.Domain.Entities.Aggregates;
using EmployerService.Infrastructure.Entities;

namespace EmployerService.Infrastructure.Mappings
{
    public class DomainEmployerMapping : Profile
    {
        public DomainEmployerMapping()
        {
            CreateMap<Employer, EmployerEntity>()
                .ConvertUsing(src => CreateInfrastructureEmployer(src));
        }

        private EmployerEntity CreateInfrastructureEmployer(Employer src)
        {
            return new EmployerEntity
            {
                Id = src.Id.Value,
                UserId = src.UserId.Value,
                CompanyName = src.CompanyName,
                CompanyDescription = src.CompanyDescription,
                Industry = src.Industry,
                CompanySize = src.CompanySize.Value,
                ContactEmail = src.ContactEmail.Value,
                CreatedAt = src.CreatedAt,
                UpdatedAt = src.UpdatedAt
            };
        }
    }
}
