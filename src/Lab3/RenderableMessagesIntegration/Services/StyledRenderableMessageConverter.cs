using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.Services;
using Itmo.ObjectOrientedProgramming.Lab3.RenderableMessagesIntegration.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Renderables.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Renderables.Services;

namespace Itmo.ObjectOrientedProgramming.Lab3.RenderableMessagesIntegration.Services;

public static class StyledRenderableMessageConverter
{
    public static RenderableMessage Convert(Message message, Color color) => new(
        new Text(message.Title).WithModifier(new ColorModifier(color)),
        new Text(message.Body),
        message.ImportanceLevel);
}