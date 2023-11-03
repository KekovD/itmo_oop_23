using Itmo.ObjectOrientedProgramming.Lab3.RenderableMessagesIntegration.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messengers.Models;

public interface IMessenger : IRenderableMessageHandling
{
    string Name { get; }
}