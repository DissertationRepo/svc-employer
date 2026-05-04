using AutoMapper;
using EmployerService.Application.Abstract_Services;
using EmployerService.Domain.Entities.Aggregates;
using EmployerService.Domain.ValueObjects;
using EmployerService.Infrastructure.Entities;
using EmployerService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EmployerService.Infrastructure.Repository
{
    public class EmployerRepository : IEmployerRepository
    {
        private readonly EmployerDbContext _db;
        private readonly IMapper _mapper;

        public EmployerRepository(EmployerDbContext db, IMapper mapper)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task AddEmployerAsync(Employer employer)
        {
            var entity = _mapper.Map<EmployerEntity>(employer);
            try
            {
                await _db.Employers.AddAsync(entity);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while adding the employer. Exception Message: {ex.Message}", ex);
            }
        }

        public async Task<Employer?> GetEmployerByIdAsync(Guid id)
        {
            var entity = await _db.Employers.FindAsync(id);
            return entity is null ? null : MapToDomain(entity);
        }

        public async Task<Employer?> GetEmployerByUserIdAsync(Guid userId)
        {
            var entity = await _db.Employers.FirstOrDefaultAsync(e => e.UserId == userId);
            return entity is null ? null : MapToDomain(entity);
        }

        public async Task<bool> UpdateEmployerAsync(
            Guid employerId,
            string companyName,
            string? companyDescription,
            string industry,
            string companySize,
            string contactEmail)
        {
            var entity = await _db.Employers.FirstOrDefaultAsync(e => e.Id == employerId);
            if (entity is null)
            {
                return false;
            }

            var domainEmployer = MapToDomain(entity);
            domainEmployer.UpdateProfile(
                companyName,
                companyDescription,
                industry,
                new CompanySize(companySize),
                new Email(contactEmail));

            entity.CompanyName = domainEmployer.CompanyName;
            entity.CompanyDescription = domainEmployer.CompanyDescription;
            entity.Industry = domainEmployer.Industry;
            entity.CompanySize = domainEmployer.CompanySize.Value;
            entity.ContactEmail = domainEmployer.ContactEmail.Value;
            entity.UpdatedAt = domainEmployer.UpdatedAt;

            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteEmployerAsync(Guid employerId)
        {
            var entity = await _db.Employers.FirstOrDefaultAsync(e => e.Id == employerId);
            if (entity is null)
            {
                return false;
            }

            _db.Employers.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        private static Employer MapToDomain(EmployerEntity entity)
        {
            return Employer.Load(
                new EmployerId(entity.Id),
                new UserId(entity.UserId),
                entity.CompanyName,
                entity.CompanyDescription,
                entity.Industry,
                new CompanySize(entity.CompanySize),
                new Email(entity.ContactEmail),
                entity.CreatedAt,
                entity.UpdatedAt);
        }
    }
}
