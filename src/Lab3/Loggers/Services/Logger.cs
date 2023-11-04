using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Loggers.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Loggers.Services;

public class Logger : ILogger
{
    public ILogger Save(IList<Message> logList, Message message)
    {
        logList.Add(message);
        return this;
    }
}