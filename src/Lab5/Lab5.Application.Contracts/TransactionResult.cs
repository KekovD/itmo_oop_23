namespace Lab5.Application.Contracts;

public abstract record TransactionResult
{
    private TransactionResult() { }

    public sealed record Success : TransactionResult;

    public sealed record Rejected : TransactionResult;
}