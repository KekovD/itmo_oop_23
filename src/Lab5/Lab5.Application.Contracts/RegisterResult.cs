namespace Lab5.Application.Contracts;

public abstract record RegisterResult
{
    private RegisterResult() { }

    public sealed record Success : RegisterResult;

    public sealed record AccountAlreadyExists : RegisterResult;
}