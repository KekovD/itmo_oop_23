using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.LabException;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.AdditionalEquipment;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Space;

public class NitrinoParticleNebulae : BaseSpace, INitrinoParticleNebulae
{
    public NitrinoParticleNebulae(int routeLength, IEnumerable<int> numberOfObstaclesOnRoute, IEnumerable<BaseObstacles> manyObstacles)
        : base(routeLength)
    {
        NumberOfObstaclesOnRoute = new List<int>(numberOfObstaclesOnRoute);
        TypeOfObstacles = new Collection<BaseObstacles>();

        foreach (BaseObstacles obstacle in manyObstacles)
        {
            if (obstacle is not INitrinoParticleNebulae)
            {
                throw new ObstacleDoesNotMatchEnvironmentException(nameof(NitrinoParticleNebulae));
            }

            TypeOfObstacles.Add(obstacle);
        }

        if (NumberOfObstaclesOnRoute.Count != TypeOfObstacles.Count)
        {
            throw new DifferentLengthCollectionsWhenCreatingSpaceException(nameof(NitrinoParticleNebulae));
        }
    }

    public override bool TryTraverseRouteDistance(BaseShip ship, int distance)
    {
        if (ship is not INitrinoParticleNebulae)
        {
            return false;
        }

        return true;
    }

    public override bool TryTraverseRouteDamage(BaseShip ship)
    {
        if (TypeOfObstacles == null)
        {
            throw new PartOfSpaceNullException(nameof(TypeOfObstacles));
        }

        if (NumberOfObstaclesOnRoute == null)
        {
            throw new PartOfSpaceNullException(nameof(NumberOfObstaclesOnRoute));
        }

        int iterator = 0;
        int counterObstacles = 0;
        foreach (BaseObstacles obstacles in TypeOfObstacles)
        {
            if (ship.AdditionalEquipment.Any(equipment => equipment is AntiNitrinoEmitter) == false &&
                NumberOfObstaclesOnRoute[iterator] != 0)
            {
                for (int i = 1; i < NumberOfObstaclesOnRoute[iterator]; i++)
                {
                    ship.TakingDamage(obstacles);
                    counterObstacles++;
                    if (ship.ShipAlive == false)
                    {
                        SetNumberOfObstacles(NumberOfObstaclesOnRoute[iterator] - counterObstacles, iterator);
                        return false;
                    }
                }

                SetNumberOfObstacles(NumberOfObstaclesOnRoute[iterator] - counterObstacles, iterator);
                counterObstacles = 0;
            }

            iterator++;
        }

        if (ship.ShipAlive == false)
        {
            return false;
        }

        return true;
    }
}