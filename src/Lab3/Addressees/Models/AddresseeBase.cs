using Itmo.ObjectOrientedProgramming.Lab3.MessageHandlers.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Proxies.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees.Models;

public abstract class AddresseeBase : IAddresseeType
{
    protected AddresseeBase()
    {
    }

    public IProxy? ImportanceFilterProxy { get; protected init; }
    public abstract IMessageHandling MessageHandling(Message message);
}