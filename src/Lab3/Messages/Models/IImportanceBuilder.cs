namespace Itmo.ObjectOrientedProgramming.Lab3.Messages.Models;

public interface IImportanceBuilder
{
    IMessageBuilder WithImportance(int importance);
}