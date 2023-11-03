namespace Itmo.ObjectOrientedProgramming.Lab3.Messages.Models;

public interface IBodyBuilder
{
    IImportanceBuilder WithBody(string body);
}