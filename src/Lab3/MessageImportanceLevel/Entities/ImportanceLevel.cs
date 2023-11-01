using Itmo.ObjectOrientedProgramming.Lab3.MessageImportanceLevel.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.MessageImportanceLevel.Entities;

public class ImportanceLevel : IImportanceLevel
{
    public ImportanceLevel(int importance)
    {
        Importance = importance;
    }

    public int Importance { get; }
}