using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.ModeStrategies.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

public interface IContextBuilder
{
    IContextBuilder WithState(StateBase state);
    IContextBuilder WithMoreAddressParser(IAddressParser addressParser);
    IContextBuilder WithMoreStrategy(IStrategy strategy);
    IContextBuilder WithAddress(string address);
    IContextBuilder WithDrive(string drive);
    IContextBuilder WithFlags(IList<Flag> flags);
    Context Create();
}