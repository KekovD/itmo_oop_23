namespace Application.Models.Accounts;

public record CustomerAccount(
    long AccountId,
    decimal Balance,
    AccountState State,
    DateTime OpenDate,
    DateTime? CloseDate);