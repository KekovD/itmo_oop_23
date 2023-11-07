using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.MessageHandlers.Models;

public interface IMessageHandling
{
    IMessageHandling MessageHandling(Message message);
}