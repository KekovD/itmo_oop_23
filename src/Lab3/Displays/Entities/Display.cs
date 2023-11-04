using Itmo.ObjectOrientedProgramming.Lab3.Displays.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Messengers.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.RenderableMessagesIntegration.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.RenderableMessagesIntegration.Models;
using Itmo.ObjectOrientedProgramming.Lab3.RenderableMessagesIntegration.Services;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays.Entities;

public class Display : IDisplay
{
    public Display(string name)
    {
        Name = name;
    }

    public string Name { get; }
    public RenderableMessage? RenderableMessage { get; private set; }

    public string Render()
    {
        if (RenderableMessage is null)
            throw new RenderNullException(nameof(Messenger));

        return new RenderMessage(RenderableMessage).Render();
    }

    public IRenderableMessageHandling RenderableMessageHandling(RenderableMessage message)
    {
        RenderableMessage = message;
        return this;
    }
}