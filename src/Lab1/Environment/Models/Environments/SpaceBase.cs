using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Environments;

public abstract class SpaceBase
{
    protected SpaceBase(int routeLength)
    {
        RouteLength = routeLength;
    }

    public int RouteLength { get; }
    protected IList<ObstaclesBase> TypeOfObstacles { get; init; } = new List<ObstaclesBase>();

    public abstract bool TryTraverseRouteDistance(ShipBase ship, int distance);

    public void TraverseRouteDamage(ShipBase ship)
    {
        foreach (ObstaclesBase obstacles in TypeOfObstacles)
        {
            int obstaclesCollidedCounter = 1;
            while (obstaclesCollidedCounter < obstacles.ObstaclesCounter)
            {
                ship.TakingDamage(obstacles);

                if (ship.ShipAlive == false)
                {
                    obstacles.ModifyNumberOfObstacles(obstaclesCollidedCounter);
                    return;
                }

                obstaclesCollidedCounter++;
            }

            obstacles.ModifyNumberOfObstacles(obstaclesCollidedCounter);
        }
    }
}