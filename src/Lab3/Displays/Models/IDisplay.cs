using Itmo.ObjectOrientedProgramming.Lab3.RenderableMessagesIntegration.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.RenderableMessagesIntegration.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Renderables.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays.Models;

public interface IDisplay : IRenderableMessageHandling, IRenderable
{
    string Name { get; }
    RenderableMessage? RenderableMessage { get; }
}