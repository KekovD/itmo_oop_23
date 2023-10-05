namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces.RouteBaseInterface;

public interface IRouteLength : INumberOfObstaclesOnRoute
{
    int RouteLength { get; }
}