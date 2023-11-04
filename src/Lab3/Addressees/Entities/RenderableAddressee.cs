using Itmo.ObjectOrientedProgramming.Lab3.Addressees.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.ExtensionAdapters.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.MessageHandlers.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Proxies.Services;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees.Entities;

public class RenderableAddressee : AddresseeBase
{
    private readonly RenderableIntegration _concreteAddressee;

    public RenderableAddressee(RenderableIntegration renderable, int importanceLevel)
    {
        _concreteAddressee = renderable;
        ImportanceFilterProxy = new Proxy(_concreteAddressee, importanceLevel);
    }

    public override IMessageHandling MessageHandling(Message message)
    {
        if (ImportanceFilterProxy is null)
            throw new ProxyNullException(nameof(UserAddressee));

        ImportanceFilterProxy.MessageHandling(message);

        return this;
    }
}