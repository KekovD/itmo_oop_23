using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandStrategies.Models;

public interface IStrategy
{
    void Execute(IContext context, IList<string> request);
}