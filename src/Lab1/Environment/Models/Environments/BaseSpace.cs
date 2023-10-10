using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.LabException;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Environments;

public abstract class BaseSpace
{
    protected BaseSpace(int routeLength)
    {
        RouteLength = routeLength;
    }

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

    public abstract bool TryTraverseRouteDistance(BaseShip ship, int distance);
    public abstract bool TryTraverseRouteDamage(BaseShip ship);
}