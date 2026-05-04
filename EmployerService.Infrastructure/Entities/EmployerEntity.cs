namespace EmployerService.Infrastructure.Entities;

public sealed class EmployerEntity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string CompanyName { get; set; } = null!;
    public string? CompanyDescription { get; set; }
    public string Industry { get; set; } = null!;
    public string CompanySize { get; set; } = null!;
    public string ContactEmail { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
