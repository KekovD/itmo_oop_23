using Itmo.ObjectOrientedProgramming.Lab3.MessageImportanceLevel.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.MessageImportanceLevel.Entities;

public class MediumImportance : IImportanceLevel
{
    private const int ImportanceLevel = 2;

    public int Importance { get; } = ImportanceLevel;
}