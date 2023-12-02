using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.CommandStrategies.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ConsoleModeIntegration.Models;

public record StrategyCommandPair(CommandBase Command, IStrategy Strategy);