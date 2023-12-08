namespace Application.Models.Accounts;

public record CustomerAccount(
    long AccountId,
    long UserId,
    decimal Balance,
    CustomerAccountState State,
    DateTime OpenDate,
    DateTime? CloseDate);