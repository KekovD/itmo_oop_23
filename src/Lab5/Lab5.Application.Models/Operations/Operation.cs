namespace Application.Models.Operations;

public record Operation(decimal AccountId, long OperationId, decimal Amount, OperationType Type, OperationState State, DateTime Date);