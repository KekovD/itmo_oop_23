using Itmo.ObjectOrientedProgramming.Lab3.Loggers.Models;
using Itmo.ObjectOrientedProgramming.Lab3.MessageHandlers.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Proxies.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees.Models;

public abstract class AddresseeBase : IAddresseeType
{
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
        if (ImportanceFilterProxy.TrySendMessage(message)) MessageLog.Save(message);
    }
}