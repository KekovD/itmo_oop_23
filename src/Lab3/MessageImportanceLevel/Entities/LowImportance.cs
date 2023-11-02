using Itmo.ObjectOrientedProgramming.Lab3.MessageImportanceLevel.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.MessageImportanceLevel.Entities;

public class LowImportance : IImportanceLevel
{
    private const int ImportanceLevel = 1;

    public int Importance { get; } = ImportanceLevel;
}