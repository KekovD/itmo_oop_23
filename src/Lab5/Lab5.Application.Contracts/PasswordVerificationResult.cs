namespace Lab5.Application.Contracts;

public abstract record PasswordVerificationResult
{
    private PasswordVerificationResult() { }
    public sealed record Success : PasswordVerificationResult;

    public sealed record Failure : PasswordVerificationResult;
}