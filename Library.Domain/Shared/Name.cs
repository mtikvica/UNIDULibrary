namespace Library.Domain.Shared;
public sealed record Name
{
    public const int MaxLength = 50;

    public string Value { get; init; }

    private Name(string value)
    {
        Value = value;
    }

    public static Name Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("First name cannot be empty", nameof(value));
        }
        if (value.Length > MaxLength)
        {
            throw new ArgumentException($"First name cannot be longer than {MaxLength} characters", nameof(value));
        }

        return new Name(value);
    }
}
