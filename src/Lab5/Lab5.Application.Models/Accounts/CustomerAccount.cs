namespace Application.Models.Accounts;

public record CustomerAccount(
    long AccountId,
    decimal Balance,
    CustomerAccountState State,
    DateTime OpenDate,
    DateTime? CloseDate);