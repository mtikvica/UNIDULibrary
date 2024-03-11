using System.Security.Cryptography;

namespace Library.Domain.Users;
public sealed record Password
{
    const int keySize = 32;
    const int iterations = 10000;
    public const int MaxLength = 50;

    public string Value { get; init; }

    private Password(string value)
    {
        Value = value;
    }

    public static Password Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Password cannot be empty", nameof(value));
        }
        if (value.Length > MaxLength)
        {
            throw new ArgumentException("Password cannot be longer than {MaxLength} characters", nameof(value));
        }
        if (value.Length < 8)
        {
            throw new ArgumentException("Password cannot be shorter than 8 characters", nameof(value));
        }
        if (!value.Any(char.IsUpper))
        {
            throw new ArgumentException("Password must contain at least one uppercase letter", nameof(value));
        }
        if (!value.Any(char.IsLower))
        {
            throw new ArgumentException("Password must contain at least one lowercase letter", nameof(value));
        }
        if (!value.Any(char.IsDigit))
        {
            throw new ArgumentException("Password must contain at least one digit", nameof(value));
        }

        return new Password(HashPassword(value));
    }

    private static string HashPassword(string password)
    {
        using var algorithm = new Rfc2898DeriveBytes(
                            password,
                            keySize,
                            iterations,
                            HashAlgorithmName.SHA512);

        var key = Convert.ToBase64String(algorithm.GetBytes(keySize));
        var salt = Convert.ToBase64String(algorithm.Salt);

        return $"{iterations}.{salt}.{key}";
    }

    public bool VerifyPassword(string password)
    {
        var parts = Value.Split('.', 3);

        if (parts.Length != 3)
        {
            throw new FormatException("Unexpected hash format. Should be formatted as `{iterations}.{salt}.{hash}`");
        }

        var iterations = Convert.ToInt32(parts[0]);
        var salt = Convert.FromBase64String(parts[1]);
        var key = Convert.FromBase64String(parts[2]);

        using var algorithm = new Rfc2898DeriveBytes(
                            password,
                            salt,
                            iterations,
                            HashAlgorithmName.SHA512);

        var keyToCheck = algorithm.GetBytes(keySize);

        var verified = keyToCheck.SequenceEqual(key);

        return verified;
    }
}
