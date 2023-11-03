using Itmo.ObjectOrientedProgramming.Lab3.Loggers.Models;
using Itmo.ObjectOrientedProgramming.Lab3.MessageHandlers.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees.Models;

public interface IAddresseeType : IMessageHandling
{
    ILogger MessageLog { get; }
}