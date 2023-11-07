using System;
using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Displays.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.RenderableMessagesIntegration.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.RenderableMessagesIntegration.Services;
using Itmo.ObjectOrientedProgramming.Lab3.Renderables.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Renderables.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays.Services;

public class DisplayDriver : IDisplayDriver, IDrawMessageHandler
{
    private readonly IDisplay _display;

    public DisplayDriver(IDisplay display)
    {
        _display = display;
    }

    public void ClearOutput() => Console.Clear();

    public RenderableMessage SetTitleColor(Color color) =>
        new StyledRenderableMessageDebuilder(_display.RenderableMessage ?? throw new BuilderNullException(nameof(SetTitleColor)))
            .SetTitleColor(color)
            .Build();

    public RenderableMessage SetBodyColor(Color color) =>
        new StyledRenderableMessageDebuilder(_display.RenderableMessage ?? throw new BuilderNullException(nameof(SetBodyColor)))
            .SetBodyColor(color)
            .Build();

    public void WriteText(Text text) => Console.WriteLine(text.Render());

    public void DrawMessage() => Console.WriteLine($"{_display.Name}:\n{_display.Render()}");
}