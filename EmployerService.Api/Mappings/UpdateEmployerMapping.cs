using AutoMapper;
using EmployerService.Api.Models;
using EmployerService.Application.Models;

namespace EmployerService.Api.Mappings
{
    public class UpdateEmployerMapping : Profile
    {
        public UpdateEmployerMapping()
        {
            CreateMap<UpdateEmployer, UpdateEmployerModel>()
                .ConvertUsing(src => new UpdateEmployerModel(
                    src.Id!,
                    src.CompanyName!,
                    src.Industry!,
                    src.CompanySize!,
                    src.ContactEmail!)
                {
                    CompanyDescription = src.CompanyDescription
                });
        }
    }
}
