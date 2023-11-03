using Itmo.ObjectOrientedProgramming.Lab3.Addressees.Models;
using Itmo.ObjectOrientedProgramming.Lab3.LabException;
using Itmo.ObjectOrientedProgramming.Lab3.MessageHandlers.Models;
using Itmo.ObjectOrientedProgramming.Lab3.MessageImportanceLevel.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Proxies.Services;
using Itmo.ObjectOrientedProgramming.Lab3.Users.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees.Entities;

public class UserAddressee : AddresseeBase
{
    private readonly UserBase _concreteAddressee;

    public UserAddressee(UserBase user, IImportanceLevel importanceLevel)
    {
        _concreteAddressee = user;
        ImportanceFilterProxy = new Proxy(_concreteAddressee, importanceLevel);
    }

    public override IMessageHandling MessageHandling(Message message)
    {
        if (ImportanceFilterProxy is null)
            throw new ProxyNullException(nameof(UserAddressee));

        ImportanceFilterProxy.MessageHandling(message);
        SaveLog(message);

        return this;
    }
}