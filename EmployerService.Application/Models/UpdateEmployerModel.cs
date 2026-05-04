namespace EmployerService.Application.Models
{
    public record UpdateEmployerModel
    {
        private readonly string _id;
        private readonly string _companyName;
        private readonly string _industry;
        private readonly string _companySize;
        private readonly string _contactEmail;

        public UpdateEmployerModel(
            string id,
            string companyName,
            string industry,
            string companySize,
            string contactEmail)
        {
            _id = id ?? throw new ArgumentNullException(nameof(id), "Id is required.");
            _companyName = !string.IsNullOrWhiteSpace(companyName)
                ? companyName
                : throw new ArgumentNullException(nameof(companyName), "CompanyName is required.");
            _industry = !string.IsNullOrWhiteSpace(industry)
                ? industry
                : throw new ArgumentNullException(nameof(industry), "Industry is required.");
            _companySize = !string.IsNullOrWhiteSpace(companySize)
                ? companySize
                : throw new ArgumentNullException(nameof(companySize), "CompanySize is required.");
            _contactEmail = !string.IsNullOrWhiteSpace(contactEmail)
                ? contactEmail
                : throw new ArgumentNullException(nameof(contactEmail), "ContactEmail is required.");
        }

        public string Id => _id;
        public string CompanyName => _companyName;
        public string Industry => _industry;
        public string CompanySize => _companySize;
        public string ContactEmail => _contactEmail;
        public string? CompanyDescription { get; init; }
    }
}
