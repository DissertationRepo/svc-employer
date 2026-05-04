using EmployerService.Application.Models;
using EmployerService.Domain.Entities.Aggregates;

namespace EmployerService.Application.Abstract_Services
{
    public interface IEmployerService
    {
        Task CreateEmployerAsync(EmployerModel newEmployer);
        Task<Employer?> GetEmployerByIdAsync(Guid id);
        Task<Employer?> GetEmployerByUserIdAsync(Guid userId);
        Task<bool> UpdateEmployerAsync(UpdateEmployerModel employerModel);
        Task<bool> DeleteEmployerAsync(string employerId);
    }
}
