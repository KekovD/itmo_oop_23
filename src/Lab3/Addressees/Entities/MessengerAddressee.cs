using Itmo.ObjectOrientedProgramming.Lab3.Addressees.Models;
using Itmo.ObjectOrientedProgramming.Lab3.MessageHandlers.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees.Entities;

public class MessengerAddressee : AddresseeBase
{
    public override IMessageHandling MessageHandling(Message message)
    {
        throw new System.NotImplementedException();
    }
}