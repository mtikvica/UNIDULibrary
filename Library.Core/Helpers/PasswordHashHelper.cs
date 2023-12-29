using System.Security.Cryptography;

namespace Library.Core.Helpers;

public static class PasswordHashHelper
{
    const int keySize = 32;
    const int iterations = 10000;

    public static string HashPassword(string password)
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

    public static bool VerifyPassword(string password, string hashedPassword)
    {
        var parts = hashedPassword.Split('.', 3);

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