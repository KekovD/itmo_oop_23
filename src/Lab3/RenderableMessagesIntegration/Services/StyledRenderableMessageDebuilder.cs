using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.Services;
using Itmo.ObjectOrientedProgramming.Lab3.RenderableMessagesIntegration.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.RenderableMessagesIntegration.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Renderables.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Renderables.Services;

namespace Itmo.ObjectOrientedProgramming.Lab3.RenderableMessagesIntegration.Services;

public class StyledRenderableMessageDebuilder : IStyledRenderableMessageDebuilder
{
    private readonly IRenderable _title;
    private readonly IRenderable _body;
    private readonly int _importance;
    private Color _titleColor = Color.Empty;
    private Color _bodyColor = Color.Empty;

    public StyledRenderableMessageDebuilder(RenderableMessage message)
    {
        _title = message.Title;
        _body = message.Body;
        _importance = message.ImportanceLevel;
    }

    public IStyledRenderableMessageDebuilder SetTitleColor(Color color)
    {
        _titleColor = color;
        return this;
    }

    public IStyledRenderableMessageDebuilder SetBodyColor(Color color)
    {
        _bodyColor = color;
        return this;
    }

    public RenderableMessage Build()
    {
        return new RenderableMessage(
            _title.WithModifier(new ColorModifier(_titleColor)),
            _body.WithModifier(new ColorModifier(_bodyColor)),
            _importance);
    }
}