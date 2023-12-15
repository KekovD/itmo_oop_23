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

    public IEnumerable<Operation> FindOperationsHistoryByAccountId(long accountId)
    {
        const string sql = """
                           select account_id, operation_id, operation_amount, operation_type, operation_state, operation_date
                           from customers_accounts_operations_history
                           where account_id = @accountId;
                           """;

        NpgsqlConnection connection = Task
            .Run(async () =>
                await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false)).GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("accountId", accountId);

        using NpgsqlDataReader reader = command.ExecuteReader();

        var operations = new List<Operation>();

        const int accountIdIndex = 0;
        const int operationIdIndex = 1;
        const int amountIndex = 2;
        const int typeIndex = 3;
        const int stateIndex = 4;
        const int dateIndex = 5;

        while (reader.Read())
        {
            operations.Add(new Operation(
                AccountId: reader.GetInt64(accountIdIndex),
                OperationId: reader.GetInt64(operationIdIndex),
                Amount: reader.GetDecimal(amountIndex),
                Type: reader.GetFieldValue<OperationType>(typeIndex),
                State: reader.GetFieldValue<OperationState>(stateIndex),
                Date: reader.GetDateTime(dateIndex)));
        }

        return operations;
    }

    public IEnumerable<Operation> FindPeriodOperationsHistoryByAccountId(long accountId, DateTime startDate, DateTime endDate)
    {
        const string sql = """
                           select account_id, operation_id, operation_amount, operation_type, operation_state, operation_date
                           from customers_accounts_operations_history
                           where account_id = @accountId and operation_date between @startDate and @endDate;
                           """;

        NpgsqlConnection connection = Task
            .Run(async () =>
                await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false)).GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("accountId", accountId);
        command.AddParameter("startDate", startDate);
        command.AddParameter("endDate", endDate);

        using NpgsqlDataReader reader = command.ExecuteReader();

        var operations = new List<Operation>();

        const int accountIdIndex = 0;
        const int operationIdIndex = 1;
        const int amountIndex = 2;
        const int typeIndex = 3;
        const int stateIndex = 4;
        const int dateIndex = 5;

        while (reader.Read())
        {
            operations.Add(new Operation(
                AccountId: reader.GetInt64(accountIdIndex),
                OperationId: reader.GetInt64(operationIdIndex),
                Amount: reader.GetDecimal(amountIndex),
                Type: reader.GetFieldValue<OperationType>(typeIndex),
                State: reader.GetFieldValue<OperationState>(stateIndex),
                Date: reader.GetDateTime(dateIndex)));
        }

        return operations;
    }

    public void AddOperationToHistory(Operation operation)
    {
        const string sql = """
                           insert into customers_accounts_operations_history(account_id, operation_amount, operation_type, operation_state, operation_date)
                           values(@accountId, @operationAmount, @operationType, @operationState, @operationDate);
                           """;

        NpgsqlConnection connection = Task
            .Run(async () =>
                await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false)).GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("accountId", operation.AccountId);
        command.AddParameter("operationAmount", operation.Amount);
        command.AddParameter("operationType", operation.Type);
        command.AddParameter("operationState", operation.State);
        command.AddParameter("operationDate", operation.Date);
        command.ExecuteNonQueryAsync().ConfigureAwait(false);
    }
}