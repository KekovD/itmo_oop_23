namespace Application.Models.Accounts;

public record CustomerAccount(
    long UserId,
    int AccountId,
    decimal Balance,
    CustomerAccountState State,
    DateTime OpenDate,
    DateTime? CloseDate);