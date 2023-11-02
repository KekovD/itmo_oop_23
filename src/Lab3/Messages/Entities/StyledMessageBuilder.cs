using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.MessageImportanceLevel.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Renderables.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Renderables.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;

public class StyledMessageBuilder : MessageBuilderBase, IColorBuilder
{
    private Color _color;

    public static IColorBuilder StyledBuilder => new StyledMessageBuilder();

    public ITitleBuilder WithColor(Color color)
    {
        _color = color;
        return this;
    }

    protected override Message Crate(
        IRenderable title,
        IRenderable body,
        IImportanceLevel importance)
    {
        return new Message(
            title.WithModifier(new ColorModifier(_color)),
            body,
            importance);
    }
}