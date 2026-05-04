namespace EmployerService.Domain.ValueObjects;

public sealed record EmployerId
{
    public Guid Value { get; }

    public EmployerId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException("EmployerId cannot be empty.", nameof(value));
        }

        Value = value;
    }

    public static EmployerId New() => new(Guid.NewGuid());

    public override string ToString() => Value.ToString();

    public static implicit operator Guid(EmployerId id) => id.Value;
}
