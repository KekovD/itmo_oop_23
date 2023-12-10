namespace Workshop5.Application.Contracts;

public interface IPasswordHasher
{
    string HashPassword(string password);
    PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword);
}