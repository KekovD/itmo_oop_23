using System;
using System.Collections.Generic;
using System.Linq;
using Application.Abstractions.Repositories;
using Application.Models.Operations;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests.Moqs;

public class MoqOperationsHistoryRepository : IOperationsHistoryRepository
{
    public IList<Operation> Operations { get; } = new List<Operation>();

    public IEnumerable<Operation> FindOperationsHistoryByAccountId(long accountId) =>
        Operations.Where(operation => operation.AccountId == accountId);

    public IEnumerable<Operation> FindPeriodOperationsHistoryByAccountId(long accountId, DateTime startDate, DateTime endDate) =>
        Operations
            .Where(operation => operation.AccountId == accountId && operation.Date >= startDate && operation.Date <= endDate);

    public void AddOperationToHistory(Operation operation) => Operations.Add(operation);
}