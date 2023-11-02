using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.MessageHandlers.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees.Models;

public abstract class AddresseeBase : IMessageHandling
{
    private readonly IList<Message> _messageLog = new List<Message>();

    public abstract IMessageHandling MessageHandling(Message message);

    public void LogMessage(Message message) => _messageLog.Add(message);
}