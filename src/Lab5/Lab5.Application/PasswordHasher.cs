using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using Lab5.Application.Contracts;

namespace Lab5.Application;

internal class PasswordHasher : IPasswordHasher
{
    public string HashPassword(string password)
    {
        byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
        var builder = new StringBuilder();

        foreach (byte byteValue in bytes)
        {
            builder.Append(byteValue.ToString("x2", CultureInfo.InvariantCulture));
        }

        return builder.ToString();
    }

    public PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
    {
        string hashedProvidedPassword = HashPassword(providedPassword);

        return hashedPassword.Equals(hashedProvidedPassword, StringComparison.Ordinal)
            ? new PasswordVerificationResult.Success()
            : new PasswordVerificationResult.Failure();
    }
}