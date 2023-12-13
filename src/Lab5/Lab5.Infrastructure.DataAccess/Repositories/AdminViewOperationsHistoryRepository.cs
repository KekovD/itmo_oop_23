using Application.Abstractions.Repositories;
using Application.Models.Operations;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class AdminViewOperationsHistoryRepository : IAdminViewOperationsHistoryRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;
    private readonly IOperationsHistoryRepository _operationsHistoryRepository;

    public AdminViewOperationsHistoryRepository(IPostgresConnectionProvider connectionProvider, IOperationsHistoryRepository operationsHistoryRepository)
    {
        _connectionProvider = connectionProvider;
        _operationsHistoryRepository = operationsHistoryRepository;
    }

    public async IAsyncEnumerable<Operation> FindAllOperationsHistory()
    {
        const string sql = """
                           select account_id, operation_id, operation_amount, operation_type, operation_state, operation_date
                           from customers_accounts_operations_history;
                           """;

        await using NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        await using var command = new NpgsqlCommand(sql, connection);
        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

        const int accountIdIndex = 0;
        const int operationIdIndex = 1;
        const int amountIndex = 2;
        const int typeIndex = 3;
        const int stateIndex = 4;
        const int dateIndex = 5;

        while (await reader.ReadAsync().ConfigureAwait(false))
        {
            yield return new Operation(
                AccountId: reader.GetInt64(accountIdIndex),
                OperationId: reader.GetInt64(operationIdIndex),
                Amount: reader.GetDecimal(amountIndex),
                Type: await reader.GetFieldValueAsync<OperationType>(typeIndex),
                State: await reader.GetFieldValueAsync<OperationState>(stateIndex),
                Date: reader.GetDateTime(dateIndex));
        }
    }

    public IAsyncEnumerable<Operation> FindAllOperationsHistoryByCustomerAccountId(long customerAccountId) =>
        _operationsHistoryRepository.FindOperationsHistoryByAccountId(customerAccountId);

    public async IAsyncEnumerable<Operation> FindPeriodOperationsHistory(DateTime startDate, DateTime endDate)
    {
        const string sql = """
                           select account_id, operation_id, operation_amount, operation_type, operation_state, operation_date
                           from customers_accounts_operations_history
                           where operation_date between :startDate and :endDate;
                           """;

        await using NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        await using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("startDate", startDate);
        command.AddParameter("endDate", endDate);
        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

        const int accountIdIndex = 0;
        const int operationIdIndex = 1;
        const int amountIndex = 2;
        const int typeIndex = 3;
        const int stateIndex = 4;
        const int dateIndex = 5;

        while (await reader.ReadAsync().ConfigureAwait(false))
        {
            yield return new Operation(
                AccountId: reader.GetInt64(accountIdIndex),
                OperationId: reader.GetInt64(operationIdIndex),
                Amount: reader.GetDecimal(amountIndex),
                Type: await reader.GetFieldValueAsync<OperationType>(typeIndex),
                State: await reader.GetFieldValueAsync<OperationState>(stateIndex),
                Date: reader.GetDateTime(dateIndex));
        }
    }

    public IAsyncEnumerable<Operation> FindPeriodOperationsHistoryByCustomerAccountId(long accountId, DateTime startDate, DateTime endDate) =>
        _operationsHistoryRepository.FindPeriodOperationsHistoryByAccountId(accountId, startDate, endDate);
}