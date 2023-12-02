using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.FileCopyCommands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.FileDeleteCommands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.FileMoveCommands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.FileRenameCommands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.FileShowCommands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.TreeCommands.Entities;
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
                    new CommandRequest(
                        new List<string> { "connect", "C:\\Users" },
                        new List<Flag> { new Flag("-m", "local") },
                        0),
                    new CommandRequest(
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
        CommandChainLinkBase chain = ConnectCommandLinq.Builder().WithSubChain(new ModeConnect()).Create();
        chain.AddNext(DisconnectCommandLinq.Builder().Create());
        chain.AddNext(TreeGoToCommandLinq.Builder().Create());
        chain.AddNext(TreeListCommandLinq.Builder().WithSubChain(new DepthFlag()).Create());
        chain.AddNext(FileShowCommandLinq.Builder().WithSubChain(new ModeFlag()).Create());
        chain.AddNext(FileMoveCommandLinq.Builder().Create());
        chain.AddNext(FileCopyCommandLinq.Builder().Create());
        chain.AddNext(FileDeleteCommandLinq.Builder().Create());
        chain.AddNext(FileRenameCommandLinq.Builder().Create());

        const int firstStringCommandIndex = 0;
        const int secondStringCommandIndex = 1;

        CommandBase? connectCommand = chain.Handle((CommandRequest)consoleCommandsData[firstStringCommandIndex]);
        CommandBase? fileShowCommand = chain.Handle((CommandRequest)consoleCommandsData[secondStringCommandIndex]);

        const int nullPath = 0;
        var nullRequest = new CommandRequest(Array.Empty<string>(), Array.Empty<Flag>(), nullPath);

        Assert.True(connectCommand is not null && connectCommand.EqualCommand(new ConnectCommand(nullRequest)));
        Assert.True(fileShowCommand is not null && fileShowCommand.EqualCommand(new FileShowCommand(nullRequest)));
    }
}