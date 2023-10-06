using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces.RouteBaseInterface;

public interface IObstaclesOnRouteCount
{
    IList<int>? NumberOfObstaclesOnRoute { get; }
}