using System.Text;
using Itmo.ObjectOrientedProgramming.Lab3.RenderableMessagesIntegration.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Renderables.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.RenderableMessagesIntegration.Services;

public class RenderMessage : IRenderable
{
    private readonly RenderableMessage _renderableMessage;

    public RenderMessage(RenderableMessage renderableMessage)
    {
        _renderableMessage = renderableMessage;
    }

    public string Render()
    {
        var builder = new StringBuilder();

        builder.Append(_renderableMessage.Title)
            .Append('\n')
            .Append(_renderableMessage.Body);

        return builder.ToString();
    }
}