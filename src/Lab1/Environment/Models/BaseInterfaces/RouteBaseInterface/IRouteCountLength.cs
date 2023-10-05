namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces.RouteBaseInterface;

public interface IRouteCountLength : IObstaclesOnRouteCount
{
    int RouteLength { get; }
}