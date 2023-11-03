using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Loggers.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Loggers.Services;

public class Logger : ILogger
{
    private readonly IList<Message> _log = new List<Message>();

    public ILogger Save(Message message)
    {
        _log.Add(message);
        return this;
    }
}