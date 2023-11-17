using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.ConsoleModeIntegration.Models;

public interface ICommandParser
{
    bool TryParseBody(string consoleCommand, out IList<string> body);
    bool TryParseConsoleCommand(string consoleCommand, out Command command);
    bool TryParseFlags(string consoleCommand, IList<string> body, out IList<Flag> flags);
}