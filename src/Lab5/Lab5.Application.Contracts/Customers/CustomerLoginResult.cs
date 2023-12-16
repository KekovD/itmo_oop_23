namespace Lab5.Application.Contracts.Customers;

public abstract record CustomerLoginResult
{
    private CustomerLoginResult() { }

    public sealed record Success : CustomerLoginResult;

    public sealed record NotFound : CustomerLoginResult;

    public sealed record WrongPassword : CustomerLoginResult;

    public sealed record AccountClosed : CustomerLoginResult;
}