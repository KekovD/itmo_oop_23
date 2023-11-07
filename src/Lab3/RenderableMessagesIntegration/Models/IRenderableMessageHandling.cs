using Itmo.ObjectOrientedProgramming.Lab3.RenderableMessagesIntegration.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.RenderableMessagesIntegration.Models;

public interface IRenderableMessageHandling
{
    IRenderableMessageHandling RenderableMessageHandling(RenderableMessage message);
}