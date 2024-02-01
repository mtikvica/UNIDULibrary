namespace Library.Domain.Users;
public sealed record LastName
{
    public const int MaxLength = 50;

    public string Value { get; init; }

    private LastName(string value)
    {
        Value = value;
    }

    public static LastName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("First name cannot be empty", nameof(value));
        }
        if (value.Length > MaxLength)
        {
            throw new ArgumentException($"First name cannot be longer than {MaxLength} characters", nameof(value));
        }

        return new LastName(value);
    }
}
