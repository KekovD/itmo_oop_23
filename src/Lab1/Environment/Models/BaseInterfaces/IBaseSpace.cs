using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces;

public interface IBaseSpace
{
    int RouteLength { get; }
    IList<int>? NumberOfObstaclesOnRoute { get; }
    ICollection<BaseObstacles>? TypeOfObstacles { get; }
    void SetNumberOfObstacles(int newValue, int index);
}