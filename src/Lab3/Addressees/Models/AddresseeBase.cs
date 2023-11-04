using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Loggers.Models;
using Itmo.ObjectOrientedProgramming.Lab3.MessageHandlers.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Proxies.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees.Models;

public abstract class AddresseeBase : IAddresseeType
{
    private readonly IList<Message> _log = new List<Message>();

    protected AddresseeBase(ILogger logger)
    {
        MessageLog = logger;
    }

    public ILogger MessageLog { get; protected set; }
    public IProxy? ImportanceFilterProxy { get; protected init; }
    public abstract IMessageHandling MessageHandling(Message message);

    protected void SaveLog(Message message)
    {
        if (ImportanceFilterProxy is null) return;
        if (ImportanceFilterProxy.TrySendMessage(message)) MessageLog.Save(_log, message);
    }
}