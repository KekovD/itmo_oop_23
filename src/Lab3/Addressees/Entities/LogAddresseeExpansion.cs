using Itmo.ObjectOrientedProgramming.Lab3.Addressees.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Loggers.Models;
using Itmo.ObjectOrientedProgramming.Lab3.MessageHandlers.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees.Entities;

public class LogAddresseeExpansion : IAddresseeType
{
    private readonly AddresseeBase _addressee;
    private readonly ILogger _messageLog;

    public LogAddresseeExpansion(AddresseeBase addressee, ILogger logger)
    {
        _addressee = addressee;
        _messageLog = logger;
    }

    public IMessageHandling MessageHandling(Message message)
    {
        if (_addressee.ImportanceFilterProxy is null)
            throw new ProxyNullException(nameof(UserAddressee));

        _addressee.ImportanceFilterProxy.MessageHandling(message);
        SaveLog(message);

        return this;
    }

    private void SaveLog(Message message)
    {
        if (_addressee.ImportanceFilterProxy is null) return;
        if (_addressee.ImportanceFilterProxy.TrySendMessage(message)) _messageLog.Save(message);
    }
}