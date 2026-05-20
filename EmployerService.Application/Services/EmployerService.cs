using EmployerService.Application.Abstract_Services;
using EmployerService.Application.Models;
using EmployerService.Domain.Entities.Aggregates;

namespace EmployerService.Application.Services
{
    public class EmployerService : IEmployerService
    {
        private readonly IEmployerRepository _employerRepository;

        public EmployerService(IEmployerRepository employerRepository)
        {
            _employerRepository = employerRepository
                ?? throw new ArgumentNullException(nameof(employerRepository), "Employer repository cannot be null.");
        }

        public async Task CreateEmployerAsync(EmployerModel newEmployer)
        {
            var domainEmployer = Employer.Create(
                Guid.Parse(newEmployer.UserId),
                newEmployer.CompanyName,
                newEmployer.CompanyDescription,
                newEmployer.Industry,
                newEmployer.CompanySize,
                newEmployer.ContactEmail);

            await _employerRepository.AddEmployerAsync(domainEmployer);
        }

        public Task<Employer?> GetEmployerByIdAsync(Guid id)
        {
            return _employerRepository.GetEmployerByIdAsync(id);
        }

        public Task<Employer?> GetEmployerByUserIdAsync(Guid userId)
        {
            return _employerRepository.GetEmployerByUserIdAsync(userId);
        }

        public async Task<bool> UpdateEmployerAsync(UpdateEmployerModel employerModel)
        {
            return await _employerRepository.UpdateEmployerAsync(
                Guid.Parse(employerModel.Id),
                employerModel.CompanyName,
                employerModel.CompanyDescription,
                employerModel.Industry,
                employerModel.CompanySize,
                employerModel.ContactEmail);
        }

        public async Task<bool> DeleteEmployerAsync(string employerId)
        {
            return await _employerRepository.DeleteEmployerAsync(Guid.Parse(employerId));
        }

        public Task<IEnumerable<Employer?>> GetEmployersByCompanyNameAsync(string companyName)
        {
            return _employerRepository.GetEmployersByCompanyNameAsync(companyName);
        }
    }
}
