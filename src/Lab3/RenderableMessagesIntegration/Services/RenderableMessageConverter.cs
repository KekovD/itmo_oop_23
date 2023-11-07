using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.RenderableMessagesIntegration.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Renderables.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.RenderableMessagesIntegration.Services;

public static class RenderableMessageConverter
{
    public static RenderableMessage Convert(Message message) => new(
            new Text(message.Title),
            new Text(message.Body),
            message.ImportanceLevel);
}