using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces.RouteBaseInterface;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.ObstaclesModels;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.StandardSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.EnvironmentsOfSpaceModels;

public abstract class BaseSpace : ITypeOfSpace, IRouteCountLength, IHaveObstacles
{
    public ExistingTypesOfSpace TypeOfSpace { get; protected init; }
    public int RouteLength { get; protected init; }
    public int NumberOfObstaclesOnRoute { get; protected init; }
    public BaseStandardObstacles? TypeOfObstacles { get; protected init; }
}