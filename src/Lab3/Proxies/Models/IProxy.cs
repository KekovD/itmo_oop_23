using Itmo.ObjectOrientedProgramming.Lab3.MessageHandlers.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Proxies.Models;

public interface IProxy : IMessageHandling
{
    bool TrySendMessage(Message message);
}