using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.LabException;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Environments;

public abstract class SpaceBase
{
    protected SpaceBase(int routeLength)
    {
        RouteLength = routeLength;
    }

    public int RouteLength { get; }
    public IList<int>? NumberOfObstaclesOnRoute { get; protected init; }
    public ICollection<ObstaclesBase>? TypeOfObstacles { get; protected init; }

    public abstract bool TryTraverseRouteDistance(ShipBase ship, int distance);

    public void TraverseRouteDamage(ShipBase ship)
    {
        if (TypeOfObstacles == null)
            throw new PartOfSpaceNullException(nameof(TypeOfObstacles));

        if (NumberOfObstaclesOnRoute == null)
            throw new PartOfSpaceNullException(nameof(NumberOfObstaclesOnRoute));

        int iterator = 0;
        int counterObstacles = 0;
        foreach (ObstaclesBase obstacles in TypeOfObstacles)
        {
            for (int i = 1; i < NumberOfObstaclesOnRoute[iterator]; i++)
            {
                ship.TakingDamage(obstacles);
                counterObstacles++;
                if (ship.ShipAlive == false)
                {
                    SetNumberOfObstacles(NumberOfObstaclesOnRoute[iterator] - counterObstacles, iterator);
                    return;
                }
            }

            SetNumberOfObstacles(NumberOfObstaclesOnRoute[iterator] - counterObstacles, iterator);
            counterObstacles = 0;

            iterator++;
        }
    }

    private void SetNumberOfObstacles(int newValue, int index)
    {
        if (NumberOfObstaclesOnRoute == null)
        {
            throw new PartOfSpaceNullException(nameof(NumberOfObstaclesOnRoute));
        }

        NumberOfObstaclesOnRoute[index] = newValue;
    }
}