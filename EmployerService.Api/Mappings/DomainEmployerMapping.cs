using AutoMapper;
using EmployerService.Api.Models;
using EmployerService.Domain.Entities.Aggregates;

namespace EmployerService.Api.Mappings
{
    public class DomainEmployerMapping : Profile
    {
        public DomainEmployerMapping()
        {
            CreateMap<Employer, EmployerResponse>()
                .ConvertUsing(src => new EmployerResponse
                {
                    Id = src.Id.Value.ToString(),
                    UserId = src.UserId.Value.ToString(),
                    CompanyName = src.CompanyName,
                    CompanyDescription = src.CompanyDescription,
                    Industry = src.Industry,
                    CompanySize = src.CompanySize.Value,
                    ContactEmail = src.ContactEmail.Value,
                    CreatedAt = src.CreatedAt,
                    UpdatedAt = src.UpdatedAt
                });
        }
    }
}
