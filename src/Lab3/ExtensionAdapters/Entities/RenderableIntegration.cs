using Itmo.ObjectOrientedProgramming.Lab3.Addressees.Models;
using Itmo.ObjectOrientedProgramming.Lab3.MessageHandlers.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.RenderableMessagesIntegration.Models;
using Itmo.ObjectOrientedProgramming.Lab3.RenderableMessagesIntegration.Services;

namespace Itmo.ObjectOrientedProgramming.Lab3.ExtensionAdapters.Entities;

public class RenderableIntegration : IAddressee
{
    private readonly IRenderableMessageHandling _renderableAddressee;

    public RenderableIntegration(IRenderableMessageHandling messenger)
    {
        _renderableAddressee = messenger;
    }

    public IMessageHandling MessageHandling(Message message)
    {
        _renderableAddressee.RenderableMessageHandling(RenderableMessageConverter.Convert(message));
        return this;
    }
}