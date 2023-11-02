using Itmo.ObjectOrientedProgramming.Lab3.Addressees.Models;
using Itmo.ObjectOrientedProgramming.Lab3.MessageHandlers.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topics.Models;

public abstract class TopicBase : IMessageHandling
{
    private readonly AddresseeBase _addressee;

    protected TopicBase(string name, AddresseeBase addressee)
    {
        Name = name;
        _addressee = addressee;
    }

    public string Name { get; protected init; }

    public IMessageHandling MessageHandling(Message message) => _addressee.MessageHandling(message);
}