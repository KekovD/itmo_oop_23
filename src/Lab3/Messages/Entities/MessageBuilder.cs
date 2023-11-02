using Itmo.ObjectOrientedProgramming.Lab3.MessageImportanceLevel.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Renderables.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;

public class MessageBuilder : MessageBuilderBase
{
    public static ITitleBuilder Builder => new MessageBuilder();

    protected override Message Crate(
        IRenderable title,
        IRenderable body,
        IImportanceLevel importance)
    {
        return new Message(title, body, importance);
    }
}