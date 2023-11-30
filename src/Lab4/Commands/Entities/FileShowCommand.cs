using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.CommandStrategies.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;

public class FileShowCommand : CommandBase
{
    public FileShowCommand(CommandRequest request)
        : base(request)
    {
    }

    public override void Execute(IStrategy strategy, IContext context)
    {
        if (context.DisconnectRequest() || Request is null)
            return;

        const int pathIndex = 2;

        strategy.Execute(context, new List<string> { Request.Body[pathIndex] });
    }

    public override bool EqualCommand(CommandBase command) => command is FileShowCommand;
}