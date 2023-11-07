using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Loggers.Models;

public interface ILogger
{
    IList<Message> LogList { get; }
    ILogger Save(Message message);
}