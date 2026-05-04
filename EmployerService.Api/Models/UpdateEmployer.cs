namespace EmployerService.Api.Models
{
    public record UpdateEmployer
    {
        public string? Id { get; init; }
        public string? CompanyName { get; init; }
        public string? CompanyDescription { get; init; }
        public string? Industry { get; init; }
        public string? CompanySize { get; init; }
        public string? ContactEmail { get; init; }
    }
}
