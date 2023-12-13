namespace Lab5.Application.Contracts;

public abstract record CloseResult
{
    private CloseResult() { }

    public sealed record Success : CloseResult;

    public sealed record WrongPassword : CloseResult;

    public sealed record AccountClosed : CloseResult;
}