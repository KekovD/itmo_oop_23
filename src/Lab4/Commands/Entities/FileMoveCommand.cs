using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.CommandStrategies.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;

public class FileMoveCommand : CommandBase
{
    public FileMoveCommand(CommandRequest request)
        : base(request)
    {
    }

    public override void Execute(IStrategy strategy, IContext context)
    {
        if (context.DisconnectRequest() || Request is null) return;

        int sourceIndex = Request.PathIndex;
        int destinationIndex = sourceIndex + NextIndexIncrement;

        strategy.Execute(context, new List<string> { Request.Body[sourceIndex], Request.Body[destinationIndex] });
    }

    public override bool EqualCommand(CommandBase command) => command is FileMoveCommand;
}