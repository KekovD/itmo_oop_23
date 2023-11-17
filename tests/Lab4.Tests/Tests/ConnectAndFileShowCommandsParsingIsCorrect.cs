using System.Collections.Generic;
using System.Linq;
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
using Moq;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests.Tests;

public static class ConnectAndFileShowCommandsParsingIsCorrect
{
    public static IEnumerable<object[]> GetConsoleCommands
    {
        get
        {
            yield return new object[]
            {
                new List<object>
                {
                    "connect C:\\Users -m local",
                    "file show C:\\Users\\lavre\\Downloads\\239\\by_all\\239.txt -m console",
                    new Command(
                        new List<string> { "connect", "C:\\Users" },
                        new List<Flag> { new Flag("-m", "local") },
                        0),
                    new Command(
                        new List<string> { "file", "show", "C:\\Users\\lavre\\Downloads\\239\\by_all\\239.txt" },
                        new List<Flag> { new Flag("-m", "console") },
                        0),
                },
            };
        }
    }

    [Theory]
    [MemberData(nameof(GetConsoleCommands), MemberType = typeof(ConnectAndFileShowCommandsParsingIsCorrect))]
    private static void ConditionCheck(IList<object> consoleCommandsData)
    {
        IContext context = Context.Builder().Create();
        ICommandParser commandParser = new CommandParser();

        var mockConnectCommand = new Mock<FlagsConnectSubChainLinqBase>();

        var mockFileShowCommand = new Mock<FlagsFileShowSubChainLinkBase>();

        CommandChainLinkBase chain = DisconnectCommand.Builder().WithContext(context).Create();

        chain.AddNext(ConnectCommand.Builder().WithContext(context).WithSubChain(mockConnectCommand.Object).Create());

        chain.AddNext(TreeGoToCommand.Builder().WithContext(context).Create());

        chain.AddNext(TreeListCommand.Builder().WithContext(context).WithSubChain(
                DepthFlag.Builder().WithContext(context)
                    .Create())
            .Create());

        chain.AddNext(FileShowCommand.Builder().WithContext(context).WithSubChain(mockFileShowCommand.Object).Create());

        chain.AddNext(FileMoveCommand.Builder().WithContext(context).Create());
        chain.AddNext(FileCopyCommand.Builder().WithContext(context).Create());
        chain.AddNext(FileDeleteCommand.Builder().WithContext(context).Create());
        chain.AddNext(FileRenameCommand.Builder().WithContext(context).Create());

        bool parseResult = true;
        const int connectStringIndex = 0;
        const int fileShowStringIndex = 1;
        const int connectIndex = 2;
        const int fileShowIndex = 3;

        var connectReference = (Command)consoleCommandsData[connectIndex];
        var fileShowReference = (Command)consoleCommandsData[fileShowIndex];

        parseResult &= commandParser.TryParseConsoleCommand((string)consoleCommandsData[connectStringIndex], out Command connectCommand);
        parseResult &= commandParser.TryParseConsoleCommand((string)consoleCommandsData[fileShowStringIndex], out Command fileShowCommand);

        Assert.True(connectReference.PathIndex == connectCommand.PathIndex &&
                    connectReference.Body.SequenceEqual(connectCommand.Body) &&
                    connectReference.Flags.SequenceEqual(connectCommand.Flags));

        Assert.True(fileShowReference.PathIndex == fileShowCommand.PathIndex &&
                    fileShowReference.Body.SequenceEqual(fileShowCommand.Body) &&
                    fileShowReference.Flags.SequenceEqual(fileShowCommand.Flags));

        chain.Handle(connectCommand);

        chain.Handle(fileShowCommand);

        Assert.True(parseResult);
        mockConnectCommand.Verify(handle => handle.Handle(It.IsAny<Command>()), Times.AtLeastOnce());
        mockFileShowCommand.Verify(handle => handle.Handle(It.IsAny<Command>()), Times.AtLeastOnce());
    }
}