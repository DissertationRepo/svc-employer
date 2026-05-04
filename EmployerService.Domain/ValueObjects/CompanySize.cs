namespace EmployerService.Domain.ValueObjects;

public sealed record CompanySize
{
    private static readonly HashSet<string> AllowedValues = new(StringComparer.OrdinalIgnoreCase)
    {
        "Startup",
        "Small",
        "Medium",
        "Large",
        "Enterprise"
    };

    public string Value { get; }

    public CompanySize(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Company size is required.", nameof(value));
        }

        var normalized = value.Trim();
        if (!AllowedValues.Contains(normalized))
        {
            throw new ArgumentException(
                $"Company size '{value}' is invalid. Allowed values: {string.Join(", ", AllowedValues)}.",
                nameof(value));
        }

        Value = normalized;
    }

    public override string ToString() => Value;
}
