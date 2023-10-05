using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces.RouteBaseInterface;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.EnvironmentsOfSpaceModels;

public abstract class BaseHighDensitySpaceNebulae : BaseSpace, ISubspaceChannelLength
{
    public int SubspaceChannelLength { get; protected set; }
    public int SubspaceChannelCoordinate { get; protected set; }
}