namespace EmployerService.Api.Models
{
    public class EmployerResponse
    {
        public string? Id { get; init; }
        public string? UserId { get; init; }
        public string? CompanyName { get; init; }
        public string? CompanyDescription { get; init; }
        public string? Industry { get; init; }
        public string? CompanySize { get; init; }
        public string? ContactEmail { get; init; }
        public DateTime? CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
    }
}
