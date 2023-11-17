﻿using Itmo.ObjectOrientedProgramming.Lab4.ConsoleModeIntegration.Services;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ConsoleModeIntegration.Models;

public interface IConsoleModeBuilder
{
    IConsoleModeBuilder WithContext(IContext context);
    IConsoleModeBuilder WithChain(CommandChainLinkBase chain);
    IConsoleModeBuilder WithCommandParser(ICommandParser parser);
    ConsoleMode Create();
}