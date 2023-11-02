using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees.Models;
using Itmo.ObjectOrientedProgramming.Lab3.MessageHandlers.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees.Entities;

public class GroupAddressee : AddresseeBase
{
    private readonly IList<AddresseeBase> _concreteAddressees = new List<AddresseeBase>();

    public GroupAddressee AddAddressee(AddresseeBase addressee)
    {
        _concreteAddressees.Add(addressee);
        return this;
    }

    public override IMessageHandling MessageHandling(Message message)
    {
        foreach (AddresseeBase addressee in _concreteAddressees)
            addressee.MessageHandling(message);

        return this;
    }
}