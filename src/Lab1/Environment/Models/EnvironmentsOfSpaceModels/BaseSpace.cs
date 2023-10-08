using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.ObstaclesModels;
using Itmo.ObjectOrientedProgramming.Lab1.MyException;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.EnvironmentsOfSpaceModels;

public abstract class BaseSpace : IBaseSpaceInterface
{
    public int RouteLength { get; protected init; }
    public IList<int>? NumberOfObstaclesOnRoute { get; protected init; }
    public ICollection<BaseObstacles>? TypeOfObstacles { get; protected init; }

    public void SetNumberOfObstacles(int newValue, int index)
    {
        if (NumberOfObstaclesOnRoute == null)
        {
            throw new PartOfSpaceNullException(nameof(NumberOfObstaclesOnRoute));
        }

        NumberOfObstaclesOnRoute[index] = newValue;
    }
}