using Itmo.ObjectOrientedProgramming.Lab3.Addressees.Models;
using Itmo.ObjectOrientedProgramming.Lab3.MessageHandlers.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Users.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees.Entities;

public class UserAddressee : AddresseeBase
{
    private readonly UserBase _concreteUser;

    public UserAddressee(UserBase concreteUser)
    {
        _concreteUser = concreteUser;
    }

    public override IMessageHandling MessageHandling(Message message) => _concreteUser.MessageHandling(message);
}