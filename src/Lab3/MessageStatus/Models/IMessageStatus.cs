using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.MessageStatus.Models;

public interface IMessageStatus : ICloneable
{
    bool CheckReadMessage();

    IMessageStatus CloneWithChangeStatus();
}