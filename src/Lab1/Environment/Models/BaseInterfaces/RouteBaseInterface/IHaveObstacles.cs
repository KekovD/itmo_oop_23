using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.ObstaclesModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces.RouteBaseInterface;

public interface IHaveObstacles
{
    ICollection<BaseStandardObstacles>? TypeOfObstacles { get; }
}