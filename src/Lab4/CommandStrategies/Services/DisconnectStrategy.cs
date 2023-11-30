using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.CommandStrategies.Models;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandStrategies.Services;

public class DisconnectStrategy : IStrategy
{
    public void Execute(IContext context, IList<string> request) => context.TransitionToOtherState();
}