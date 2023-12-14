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

    public IEnumerable<Operation> FindAllOperationsHistory()
    {
        const string sql = """
                           select account_id, operation_id, operation_amount, operation_type, operation_state, operation_date
                           from customers_accounts_operations_history;
                           """;

        using NpgsqlConnection connection = Task
            .Run(async () =>
                await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false)).GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);

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

    public IEnumerable<Operation> FindAllOperationsHistoryByCustomerAccountId(long customerAccountId)
    {
        return _operationsHistoryRepository.FindOperationsHistoryByAccountId(customerAccountId);
    }

    public IEnumerable<Operation> FindPeriodOperationsHistory(DateTime startDate, DateTime endDate)
    {
        const string sql = """
                           select account_id, operation_id, operation_amount, operation_type, operation_state, operation_date
                           from customers_accounts_operations_history
                           where operation_date between @startDate and @endDate;
                           """;

        using NpgsqlConnection connection = Task
            .Run(async () =>
                await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false)).GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
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

    public IEnumerable<Operation> FindPeriodOperationsHistoryByCustomerAccountId(long accountId, DateTime startDate, DateTime endDate) =>
        _operationsHistoryRepository.FindPeriodOperationsHistoryByAccountId(accountId, startDate, endDate);
}