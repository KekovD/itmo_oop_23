using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.ConsoleModeIntegration.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.ConsoleModeIntegration.Services;

public class CommandParser : ICommandParser
{
    public bool TryParseBody(string consoleCommand, out IList<string> body)
    {
        body = Array.Empty<string>();

        var parts = consoleCommand.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
        body = parts.TakeWhile(part => !part.StartsWith("-", StringComparison.Ordinal)).ToList();

        return true;
    }

    public bool TryParseFlags(string consoleCommand, IList<string> body, out IList<Flag> flags)
    {
        var parts = consoleCommand.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
        var flagParts = parts.Skip(body.Count).ToList();

        flags = new List<Flag>();

        const int step = 2;
        const int singleStep = 1;
        const int initialIndex = 0;
        const string targetFlagSymbol = "-";

        for (int index = initialIndex; index < flagParts.Count; index += step)
        {
            if (index + singleStep >= flagParts.Count ||
                !flagParts[index].StartsWith(targetFlagSymbol, StringComparison.Ordinal))
                return false;

            flags.Add(new Flag(flagParts[index], flagParts[index + singleStep]));
        }

        return true;
    }

    public bool TryParseConsoleCommand(string consoleCommand, out Command command)
    {
        const int defaultPathIndex = 0;
        command = new Command(Array.Empty<string>(), Array.Empty<Flag>(), defaultPathIndex);

        if (!TryParseBody(consoleCommand, out IList<string> body) ||
            !TryParseFlags(consoleCommand, body, out IList<Flag> flags))
            return false;

        command = new Command(body, flags, defaultPathIndex);
        return true;
    }
}