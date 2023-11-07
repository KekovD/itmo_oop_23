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

        builder.Append(_renderableMessage.Title.Render())
            .Append('\n')
            .Append(_renderableMessage.Body.Render());

        return builder.ToString();
    }
}