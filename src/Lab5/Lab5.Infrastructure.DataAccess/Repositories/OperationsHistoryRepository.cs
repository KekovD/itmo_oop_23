using Application.Abstractions.Repositories;
using Application.Models.Operations;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class OperationsHistoryRepository : IOperationsHistoryRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public OperationsHistoryRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async IAsyncEnumerable<Operation> FindOperationsHistoryByAccountId(long accountId)
    {
        const string sql = """
                           select account_id, operation_id, operation_amount, operation_type, operation_state, operation_date
                           from customers_accounts_operations_history
                           where account_id = :accountId;
                           """;

        await using NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        await using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("accountId", accountId);
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

    public async IAsyncEnumerable<Operation> FindPeriodOperationsHistoryByAccountId(long accountId, DateTime startDate, DateTime endDate)
    {
        const string sql = """
                           select account_id, operation_id, operation_amount, operation_type, operation_state, operation_date
                           from customers_accounts_operations_history
                           where account_id = :accountId and operation_date between :startDate and :endDate;
                           """;

        await using NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        await using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("accountId", accountId);
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

    public async Task AddOperationToHistory(Operation operation)
    {
        const string sql = """
                           insert into customers_accounts_operations_history(account_id, operation_amount, operation_type, operation_state, operation_date)
                           values(:accountId, :operationAmount, :operationType, :operationState, :operationDate);
                           """;

        await using NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        await using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("accountId", operation.AccountId);
        command.AddParameter("operationAmount", operation.Amount);
        command.AddParameter("operationType", operation.Type);
        command.AddParameter("operationState", operation.State);
        command.AddParameter("operationDate", operation.Date);

        await command.ExecuteNonQueryAsync().ConfigureAwait(false);
    }
}