// EmployerService.Domain/Entities/Aggregates/Employer.cs
using EmployerService.Domain.ValueObjects;

namespace EmployerService.Domain.Entities.Aggregates;

public sealed class Employer
{
    public EmployerId Id { get; }
    public UserId UserId { get; }
    public string CompanyName { get; private set; }
    public string? CompanyDescription { get; private set; }
    public string Industry { get; private set; }
    public CompanySize CompanySize { get; private set; }
    public Email ContactEmail { get; private set; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; private set; }

    private Employer(
        EmployerId id,
        UserId userId,
        string companyName,
        string? companyDescription,
        string industry,
        CompanySize companySize,
        Email contactEmail,
        DateTime createdAt,
        DateTime updatedAt)
    {
        if (string.IsNullOrWhiteSpace(companyName))
            throw new ArgumentException("Company name is required.", nameof(companyName));

        if (string.IsNullOrWhiteSpace(industry))
            throw new ArgumentException("Industry is required.", nameof(industry));

        Id = id ?? throw new ArgumentNullException(nameof(id));
        UserId = userId ?? throw new ArgumentNullException(nameof(userId));
        CompanyName = companyName.Trim();
        CompanyDescription = NormalizeDescription(companyDescription);
        Industry = industry.Trim();
        CompanySize = companySize ?? throw new ArgumentNullException(nameof(companySize));
        ContactEmail = contactEmail ?? throw new ArgumentNullException(nameof(contactEmail));
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public static Employer Create(
        Guid userId,
        string companyName,
        string? companyDescription,
        string industry,
        string companySize,
        string contactEmail)
    {
        var now = DateTime.UtcNow;
        return new Employer(
            EmployerId.New(),
            new UserId(userId),
            companyName,
            companyDescription,
            industry,
            new CompanySize(companySize),
            new Email(contactEmail),
            now,
            now);
    }

    public void UpdateProfile(
        string companyName,
        string? companyDescription,
        string industry,
        CompanySize companySize,
        Email contactEmail)
    {
        if (string.IsNullOrWhiteSpace(companyName))
            throw new ArgumentException("Company name is required.", nameof(companyName));

        if (string.IsNullOrWhiteSpace(industry))
            throw new ArgumentException("Industry is required.", nameof(industry));

        CompanyName = companyName.Trim();
        CompanyDescription = NormalizeDescription(companyDescription);
        Industry = industry.Trim();
        CompanySize = companySize ?? throw new ArgumentNullException(nameof(companySize));
        ContactEmail = contactEmail ?? throw new ArgumentNullException(nameof(contactEmail));
        UpdatedAt = DateTime.UtcNow;
    }

    public static Employer Load(
        EmployerId id,
        UserId userId,
        string companyName,
        string? companyDescription,
        string industry,
        CompanySize companySize,
        Email contactEmail,
        DateTime createdAt,
        DateTime updatedAt)
    {
        return new Employer(
            id,
            userId,
            companyName,
            companyDescription,
            industry,
            companySize,
            contactEmail,
            createdAt,
            updatedAt);
    }

    private static string? NormalizeDescription(string? description)
    {
        return string.IsNullOrWhiteSpace(description) ? null : description.Trim();
    }
}
