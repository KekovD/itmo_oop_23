using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces.RouteBaseInterface;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.EnvironmentsOfSpaceModels;

public abstract class BaseNormalSpace : BaseSpace, ISecondNumberOfObstaclesOnRoute
{
    public int SecondNumberOfObstaclesOnRoute { get; protected init; }
}