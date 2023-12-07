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

    public IEnumerable<Operation> FindOperationsHistoryById(decimal accountId)
    {
        const string sql = """
                           select account_id, operation_id, operation_amount, operation_type, operation_state, operation_date
                           from customers_accounts_operations_history
                           where account_id = :accountId;
                           """;

        using NpgsqlConnection connection = Task
            .Run(async () =>
                await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false)).GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("accountId", accountId);
        using NpgsqlDataReader reader = command.ExecuteReader();

        const int accountIdIndex = 0;
        const int operationIdIndex = 1;
        const int amountIndex = 2;
        const int typeIndex = 3;
        const int stateIndex = 4;
        const int dateIndex = 5;

        while (reader.Read())
        {
            yield return new Operation(
                AccountId: reader.GetDecimal(accountIdIndex),
                OperationId: reader.GetInt64(operationIdIndex),
                Amount: reader.GetDecimal(amountIndex),
                Type: reader.GetFieldValue<OperationType>(typeIndex),
                State: reader.GetFieldValue<OperationState>(stateIndex),
                Date: reader.GetDateTime(dateIndex));
        }
    }
}