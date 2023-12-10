namespace Lab5.Application.Contracts;

public abstract record LoginResult
{
    private LoginResult() { }

    public sealed record Success : LoginResult;

    public sealed record NotFound : LoginResult;

    public sealed record WrongPassword : LoginResult;

    public sealed record AccountClosed : LoginResult;
}