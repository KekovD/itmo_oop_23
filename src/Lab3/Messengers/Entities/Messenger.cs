using System;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Messengers.Models;
using Itmo.ObjectOrientedProgramming.Lab3.RenderableMessagesIntegration.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.RenderableMessagesIntegration.Models;
using Itmo.ObjectOrientedProgramming.Lab3.RenderableMessagesIntegration.Services;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messengers.Entities;

public class Messenger : IMessenger
{
    private RenderableMessage? _renderableMessage;

    public Messenger(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public string Render()
    {
        if (_renderableMessage is null)
            throw new RenderNullException(nameof(Messenger));

        return new RenderMessage(_renderableMessage).Render();
    }

    public IRenderableMessageHandling RenderableMessageHandling(RenderableMessage message)
    {
        _renderableMessage = message;
        return this;
    }

    public void DrawMessage() => Console.WriteLine($"Messenger {Name}:\n{Render()}");
}