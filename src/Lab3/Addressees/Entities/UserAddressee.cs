using Itmo.ObjectOrientedProgramming.Lab3.Addressees.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.MessageHandlers.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Proxies.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Proxies.Services;
using Itmo.ObjectOrientedProgramming.Lab3.Users.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees.Entities;

public class UserAddressee : IAddresseeType
{
    private readonly UserBase _concreteAddressee;

    public UserAddressee(UserBase user, int importanceLevel)
    {
        _concreteAddressee = user;
        ImportanceFilterProxy = new Proxy(_concreteAddressee, importanceLevel);
    }

    public IProxy? ImportanceFilterProxy { get; private init; }

    public IMessageHandling MessageHandling(Message message)
    {
        if (ImportanceFilterProxy is null)
            throw new ProxyNullException(nameof(UserAddressee));

        ImportanceFilterProxy.MessageHandling(message);

        return this;
    }
}