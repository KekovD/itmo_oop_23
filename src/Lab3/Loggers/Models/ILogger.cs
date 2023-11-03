using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Loggers.Models;

public interface ILogger
{
    IList<Message> Log { get; }
    ILogger Save(Message message);
}