using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ConsoleModeIntegration.Models;
using Itmo.ObjectOrientedProgramming.Lab4.ConsoleModeIntegration.Services;
using Itmo.ObjectOrientedProgramming.Lab4.FileCopyCommands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.FileDeleteCommands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.FileMoveCommands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.FileRenameCommands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.FileShowCommands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ModeStrategies.Models;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Services;
using Itmo.ObjectOrientedProgramming.Lab4.TreeCommands.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Application;

public static class ConsoleApplication
{
    private static readonly IStrategy Strategy =
        ModeStrategies.Entities.Strategy.Builder()
            .WithConnectionMode("local")
            .WithMoreCommand(new LocalConnectedCommand())
            .WithMoreCommand(new DisconnectCommand())
            .WithMoreCommand(new LocalCopyFile())
            .WithMoreCommand(new LocalDeleteFile())
            .WithMoreCommand(new LocalConsoleFileShow())
            .WithMoreCommand(new LocalMoveFile())
            .WithMoreCommand(new LocalRenameFile())
            .WithMoreCommand(new TreeGoToCommand())
            .WithMoreCommand(LocalConsoleTreeListCommand.Builder().Create())
            .Create();

    private static readonly IContext Context =
        StatesCommands.Services.Context.Builder().WithMoreAddressParser(new LocalAddressParser()).WithMoreStrategy(Strategy).Create();

    private static readonly IConsoleMode ConsoleMode = ConsoleModeIntegration.Services.ConsoleMode.Builder()
        .WithContext(Context).WithCommandParser(new CommandParser()).WithChain(MakeChain()).Create();

    public static void Main() => ConsoleMode.EnterConsoleMode();

    private static CommandChainLinkBase MakeChain()
    {
        CommandChainLinkBase chain =
            ConnectCommand.Builder().WithContext(Context)
                .WithSubChain(ModeConnect.Builder().WithContext(Context).Create())
                .Create();

        chain.AddNext(DisconnectCommandLinq.Builder().WithContext(Context).Create());
        chain.AddNext(TreeGoToCommandLinq.Builder().WithContext(Context).Create());

        chain.AddNext(TreeListCommand.Builder().WithContext(Context).WithSubChain(
            DepthFlag.Builder().WithContext(Context)
                .Create())
            .Create());

        chain.AddNext(FileShowCommand.Builder().WithContext(Context).WithSubChain(
            ModeFlag.Builder().WithContext(Context)
                .Create())
            .Create());

        chain.AddNext(FileMoveCommand.Builder().WithContext(Context).Create());
        chain.AddNext(FileCopyCommand.Builder().WithContext(Context).Create());
        chain.AddNext(FileDeleteCommand.Builder().WithContext(Context).Create());
        chain.AddNext(FileRenameCommand.Builder().WithContext(Context).Create());

        return chain;
    }
}