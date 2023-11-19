using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;

public abstract class CommandBase
{
    protected const int NextIndex = 1;
    public Command? Request { get; protected set; }
    protected CommandFeatures? Characteristics { get; init; }

    public abstract void Execute(IContext context);

    public bool CompareCharacteristics(CommandFeatures other, Command request)
    {
        bool result = Characteristics is not null &&
                      Characteristics.Type.Equals(other.Type, StringComparison.Ordinal) &&
                      Characteristics.ConnectionMode.Equals(other.ConnectionMode, StringComparison.Ordinal) &&
                      Characteristics.OutputMode.Equals(other.OutputMode, StringComparison.Ordinal);

        Request = result ? request : Request;

        return result;
    }
}