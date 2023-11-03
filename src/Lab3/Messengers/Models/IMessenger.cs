using Itmo.ObjectOrientedProgramming.Lab3.RenderableMessagesIntegration.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Renderables.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messengers.Models;

public interface IMessenger : IRenderable, IRenderableMessageHandling
{
    string Name { get; }
}