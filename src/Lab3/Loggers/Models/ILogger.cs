using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Loggers.Models;

public interface ILogger
{
    ILogger Save(IList<Message> logList, Message message);
}