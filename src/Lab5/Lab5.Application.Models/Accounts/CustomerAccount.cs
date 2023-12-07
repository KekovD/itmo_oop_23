namespace Application.Models.Accounts;

public record CustomerAccount(
    decimal AccountId,
    long UserId,
    decimal Balance,
    CustomerAccountState State,
    DateTime OpenDate,
    DateTime? CloseDate);