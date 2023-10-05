using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces.RouteBaseInterface;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.ObstaclesModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.EnvironmentsOfSpaceModels;

public abstract class BaseNormalSpace : BaseSpace, IHaveSecondObstacles
{
    public int SecondNumberOfObstaclesOnRoute { get; protected init; }
    public BaseStandardObstacles? TypeOfSecondObstacles { get; protected init; }
}