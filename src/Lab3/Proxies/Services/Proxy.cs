using Itmo.ObjectOrientedProgramming.Lab3.Addressees.Models;
using Itmo.ObjectOrientedProgramming.Lab3.MessageHandlers.Models;
using Itmo.ObjectOrientedProgramming.Lab3.MessageImportanceLevel.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Proxies.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Proxies.Services;

public class Proxy : IProxy
{
    private readonly IAddressee _addressee;
    private readonly IImportanceLevel _addresseeImportanceLevel;

    public Proxy(IAddressee addressee, IImportanceLevel addresseeImportanceLevel)
    {
        _addressee = addressee;
        _addresseeImportanceLevel = addresseeImportanceLevel;
    }

    public bool TrySendMessage(Message message) => message.ImportanceLevel.Importance >= _addresseeImportanceLevel.Importance;

    public IMessageHandling MessageHandling(Message message)
    {
        if (TrySendMessage(message))
            _addressee.MessageHandling(message);

        return this;
    }
}