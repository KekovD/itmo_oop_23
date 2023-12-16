namespace Application.Models.Operations;

public record Operation(long AccountId, long OperationId, decimal Amount, OperationType Type, OperationState State, DateTime Date);