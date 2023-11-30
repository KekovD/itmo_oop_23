﻿using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.CommandStrategies.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;

public class ConnectCommand : CommandBase
{
    public ConnectCommand(CommandRequest request)
        : base(request)
    {
    }

    public override void Execute(IStrategy strategy, IContext context)
    {
        if (context.ConnectRequest() || Request is null)
            return;

        strategy.Execute(context, new List<string> { Request.Body[Request.PathIndex] });
    }

    public override bool EqualCommand(CommandBase command) => command is ConnectCommand;
}