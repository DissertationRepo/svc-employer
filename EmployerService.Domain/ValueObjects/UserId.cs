namespace EmployerService.Domain.ValueObjects;

public sealed record UserId
{
    public Guid Value { get; }

    public UserId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException("UserId cannot be empty.", nameof(value));
        }

        Value = value;
    }

    public override string ToString() => Value.ToString();

    public static implicit operator Guid(UserId userId) => userId.Value;
}
