using Itmo.ObjectOrientedProgramming.Lab3.RenderableMessagesIntegration.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.RenderableMessagesIntegration.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays.Models;

public interface IDisplay : IRenderableMessageHandling
{
    string Name { get; }
    RenderableMessage? RenderableMessage { get; }
    string Render();
}