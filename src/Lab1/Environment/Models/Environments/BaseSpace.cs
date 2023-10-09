﻿using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.MyException;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Environments;

public abstract class BaseSpace
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