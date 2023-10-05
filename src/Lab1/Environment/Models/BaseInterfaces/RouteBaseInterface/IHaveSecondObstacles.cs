using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.ObstaclesModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces.RouteBaseInterface;

public interface IHaveSecondObstacles : ISecondNumberOfObstaclesOnRoute
{
    BaseStandardObstacles? TypeOfSecondObstacles { get; }
}