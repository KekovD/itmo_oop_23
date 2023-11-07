using Itmo.ObjectOrientedProgramming.Lab3.RenderableMessagesIntegration.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Renderables.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messengers.Models;

public interface IMessenger : IRenderableMessageHandling, IDrawMessageHandler
{
    string Name { get; }
}