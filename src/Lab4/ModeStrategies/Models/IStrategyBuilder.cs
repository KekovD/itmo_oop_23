using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.ModeStrategies.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.ModeStrategies.Models;

public interface IStrategyBuilder
{
    IStrategyBuilder WithMoreCommand(CommandBase commandBase);
    IStrategyBuilder WithConnectionMode(string connectionMode);
    Strategy Create();
}