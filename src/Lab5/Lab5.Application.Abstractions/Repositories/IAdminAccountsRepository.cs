namespace Application.Abstractions.Repositories;

public interface IAdminAccountsRepository
{
    string? FindAdminPasswordById(long userId, decimal accountId);
}