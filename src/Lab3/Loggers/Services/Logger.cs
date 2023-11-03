using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Loggers.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Loggers.Services;

public class Logger : ILogger
{
    public IList<Message> Log { get; } = new List<Message>();

    public ILogger Save(Message message)
    {
        Log.Add(message);
        return this;
    }
}