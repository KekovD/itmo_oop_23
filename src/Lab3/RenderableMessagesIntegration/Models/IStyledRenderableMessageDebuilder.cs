using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.RenderableMessagesIntegration.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.RenderableMessagesIntegration.Models;

public interface IStyledRenderableMessageDebuilder
{
    IStyledRenderableMessageDebuilder SetTitleColor(Color color);

    IStyledRenderableMessageDebuilder SetBodyColor(Color color);

    RenderableMessage Build();
}