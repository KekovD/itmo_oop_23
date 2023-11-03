using Itmo.ObjectOrientedProgramming.Lab3.MessageImportanceLevel.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages.Services;

public class MessageBuilder : MessageBuilderBase
{
    public static ITitleBuilder Builder => new MessageBuilder();

    protected override Message Create(
        string title,
        string body,
        IImportanceLevel importance)
    {
        return new Message(title, body, importance);
    }
}