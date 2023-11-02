using Itmo.ObjectOrientedProgramming.Lab3.MessageStatus.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.MessageStatus.Entities;

public class UnreadMessageStatus : IMessageStatus
{
    public bool CheckReadMessage() => false;

    public object Clone() => new UnreadMessageStatus();

    public IMessageStatus CloneWithChangeStatus() => new ReadMessageStatus();
}