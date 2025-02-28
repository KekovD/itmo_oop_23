﻿using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;

public abstract class ChainLinkBase
{
    protected ChainLinkBase? Next { get; set; }

    public virtual void AddNext(ChainLinkBase link)
    {
        Next?.AddNext(link);
        Next ??= link;
    }

    public abstract CommandBase? Handle(CommandRequest request);
}