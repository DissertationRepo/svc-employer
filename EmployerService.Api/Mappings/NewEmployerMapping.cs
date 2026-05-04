using AutoMapper;
using EmployerService.Api.Models;
using EmployerService.Application.Models;

namespace EmployerService.Api.Mappings
{
    public class NewEmployerMapping : Profile
    {
        public NewEmployerMapping()
        {
            CreateMap<NewEmployer, EmployerModel>()
                .ConstructUsing(src => CreateApplicationEmployer(src));
        }

        private EmployerModel CreateApplicationEmployer(NewEmployer src)
        {
            return new EmployerModel(
                userId: src.UserId!,
                companyName: src.CompanyName!,
                industry: src.Industry!,
                companySize: src.CompanySize!,
                contactEmail: src.ContactEmail!)
            {
                CompanyDescription = src.CompanyDescription
            };
        }
    }
}
