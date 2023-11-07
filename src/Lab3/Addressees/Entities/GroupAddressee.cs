using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees.Models;
using Itmo.ObjectOrientedProgramming.Lab3.MessageHandlers.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees.Entities;

public class GroupAddressee : IAddresseeType
{
    private readonly IList<AddresseeBase> _addresseesGroup = new List<AddresseeBase>();

    public GroupAddressee AddAddresses(AddresseeBase addresseeBase)
    {
        _addresseesGroup.Add(addresseeBase);
        return this;
    }

    public IMessageHandling MessageHandling(Message message)
    {
        foreach (AddresseeBase addressee in _addresseesGroup)
        {
            if (addressee.ImportanceFilterProxy is null) continue;

            addressee.MessageHandling(message);
        }

        return this;
    }
}