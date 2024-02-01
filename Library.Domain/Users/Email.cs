namespace Library.Domain.Users;
public sealed record Email
{
    public const int MaxLength = 50;

    public string Value { get; init; }

    private Email(string value)
    {
        Value = value;
    }

    public static Email Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Email cannot be empty", nameof(value));
        }
        if (value.Length > MaxLength)
        {
            throw new ArgumentException($"Email cannot be longer than {MaxLength} characters", nameof(value));
        }
        if (!value.Contains("@"))
        {
            throw new ArgumentException("Email must contain @", nameof(value));
        }
        if (!value.Contains("."))
        {
            throw new ArgumentException("Email must contain .", nameof(value));
        }
        return new Email(value);
    }
}
