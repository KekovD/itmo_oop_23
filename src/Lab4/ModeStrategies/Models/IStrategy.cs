using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.ModeStrategies.Models;

public interface IStrategy
{
    CommandBase? CrateCommand(CommandFeatures commandFeatures, Command request);
    bool CompareCharacteristics(string connectionMode);
}