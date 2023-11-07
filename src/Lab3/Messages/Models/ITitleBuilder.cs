namespace Itmo.ObjectOrientedProgramming.Lab3.Messages.Models;

public interface ITitleBuilder
{
    IBodyBuilder WithTitle(string title);
}