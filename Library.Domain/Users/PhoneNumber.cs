namespace Library.Domain.Users;
public sealed record PhoneNumber
{
    private const int MaxLength = 20;
    public string Value { get; }

    private PhoneNumber(string value)
    {
        Value = value;
    }

    public static PhoneNumber Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Phone number cannot be empty", nameof(value));
        }
        if (value.Length > MaxLength)
        {
            throw new ArgumentException($"Phone number cannot be longer than {MaxLength} characters", nameof(value));
        }
        if (!value.All(char.IsDigit))
        {
            throw new ArgumentException("Phone number must contain only digits", nameof(value));
        }
        if (value.Length < 9)
        {
            throw new ArgumentException("Phone number must contain at least 9 digits", nameof(value));
        }
        if (value.Length > 12)
        {
            throw new ArgumentException("Phone number cannot contain more than 12 digits", nameof(value));
        }
        if (!(value is string))
        {
            throw new ArgumentException("Phone number must be a string", nameof(value));
        }
        if (value[0] != '0')
        {
            throw new ArgumentException("Phone number must start with 0", nameof(value));
        }

        return new PhoneNumber(value);
    }
}
