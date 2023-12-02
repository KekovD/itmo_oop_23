using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.CommandStrategies.Models;
using Itmo.ObjectOrientedProgramming.Lab4.CommandStrategies.Services;
using Itmo.ObjectOrientedProgramming.Lab4.ConsoleModeIntegration.Models;
using Itmo.ObjectOrientedProgramming.Lab4.ConsoleModeIntegration.Services;
using Itmo.ObjectOrientedProgramming.Lab4.FileCopyCommands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.FileDeleteCommands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.FileMoveCommands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.FileRenameCommands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.FileShowCommands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Services;
using Itmo.ObjectOrientedProgramming.Lab4.TreeCommands.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Application;

public static class ConsoleLocalApplication
{
    private static readonly IConsoleMode ConsoleMode = MakeConsoleMode();

    public static void Main()
    {
        string? userInput = Console.ReadLine();

        if (userInput is null) return;

        var inputList = userInput.Split(' ').ToList();

        const int targetCount = 4;
        const string targetMode = "local";

        if (inputList.Count >= targetCount && inputList.Contains(targetMode))
            ConsoleMode.EnterConsoleMode(userInput);
    }

    private static IConsoleMode MakeConsoleMode()
    {
        CommandChainLinkBase chain = ConnectCommandLinq.Builder().WithSubChain(new ModeConnect()).Create();
        chain.AddNext(DisconnectCommandLinq.Builder().Create());
        chain.AddNext(TreeGoToCommandLinq.Builder().Create());
        chain.AddNext(TreeListCommandLinq.Builder().WithSubChain(new DepthFlag()).Create());
        chain.AddNext(FileShowCommandLinq.Builder().WithSubChain(new ModeFlag()).Create());
        chain.AddNext(FileMoveCommandLinq.Builder().Create());
        chain.AddNext(FileCopyCommandLinq.Builder().Create());
        chain.AddNext(FileDeleteCommandLinq.Builder().Create());
        chain.AddNext(FileRenameCommandLinq.Builder().Create());

        const int nullIndex = 0;
        var nullRequest = new CommandRequest(Array.Empty<string>(), Array.Empty<Flag>(), nullIndex);
        IAddressParser addressParser = new LocalAddressParser();
        IOutputStrategy outputStrategy = new ConsoleOutputStrategy();

        return ConsoleModeIntegration.Services.ConsoleMode.Builder()
            .WithContext(Context.Builder().Create())
            .WithCommandParser(new CommandParser())
            .WithOutputStrategy(new ConsoleOutputStrategy())
            .WithChain(chain)
            .WithMoreStrategy(new ConnectCommand(nullRequest), new ConnectedStrategy(addressParser))
            .WithMoreStrategy(new DisconnectCommand(nullRequest), new DisconnectStrategy())
            .WithMoreStrategy(new TreeGoToCommand(nullRequest), new TreeGoToStrategy(addressParser))
            .WithMoreStrategy(new TreeListCommand(nullRequest), LocalTreeList
                .Builder()
                .WithAddressParser(addressParser)
                .WithOutput(outputStrategy)
                .Create())
            .WithMoreStrategy(new FileShowCommand(nullRequest), new LocalFileShow(addressParser, outputStrategy))
            .WithMoreStrategy(new FileMoveCommand(nullRequest), new LocalFileMove(addressParser))
            .WithMoreStrategy(new FileCopyCommand(nullRequest), new LocalFileCopy(addressParser))
            .WithMoreStrategy(new FileDeleteCommand(nullRequest), new LocalFileDelete(addressParser))
            .WithMoreStrategy(new FileRenameCommand(nullRequest), new LocalFileRename(addressParser))
            .Create();
    }
}