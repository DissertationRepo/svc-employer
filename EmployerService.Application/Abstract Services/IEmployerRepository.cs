using EmployerService.Domain.Entities.Aggregates;

namespace EmployerService.Application.Abstract_Services
{
    public interface IEmployerRepository
    {
        Task AddEmployerAsync(Employer employer);
        Task<Employer?> GetEmployerByIdAsync(Guid id);
        Task<Employer?> GetEmployerByUserIdAsync(Guid userId);
        Task<bool> UpdateEmployerAsync(
            Guid employerId,
            string companyName,
            string? companyDescription,
            string industry,
            string companySize,
            string contactEmail);
        Task<bool> DeleteEmployerAsync(Guid employerId);
    }
}
