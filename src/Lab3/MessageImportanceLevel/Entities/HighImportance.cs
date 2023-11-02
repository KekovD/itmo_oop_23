using Itmo.ObjectOrientedProgramming.Lab3.MessageImportanceLevel.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.MessageImportanceLevel.Entities;

public class HighImportance : IImportanceLevel
{
    private const int ImportanceLevel = 3;

    public int Importance { get; } = ImportanceLevel;
}