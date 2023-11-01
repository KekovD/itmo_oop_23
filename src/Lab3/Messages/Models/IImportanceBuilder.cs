using Itmo.ObjectOrientedProgramming.Lab3.MessageImportanceLevel.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages.Models;

public interface IImportanceBuilder
{
    IMessageBuilder WithImportance(IImportanceLevel importance);
}