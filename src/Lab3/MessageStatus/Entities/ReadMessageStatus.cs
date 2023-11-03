using Itmo.ObjectOrientedProgramming.Lab3.MessageStatus.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.MessageStatus.Entities;

public class ReadMessageStatus : IMessageStatus
{
    public bool CheckReadMessage() => true;
}