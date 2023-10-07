using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces.RouteBaseInterface;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.EnvironmentsOfSpaceModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Services;

public abstract class LaunchShips : TrySingleTraverseRouteDistance, ITryLaunchShips
{
    public Collection<bool> TryLaunchShips(ICollection<BaseShip> manyShips, ICollection<BaseSpace> manySegments)
    {
        var resultCollection = new Collection<bool>();

        foreach (BaseShip ship in manyShips)
        {
            bool checkAdd = true;
            foreach (BaseSpace segment in manySegments)
            {
                TryTraverseRouteDamage(ship, segment, segment.RouteLength);
                if (!TryTraverseRouteDistance(ship, segment, segment.RouteLength))
                {
                    checkAdd = false;
                }
            }

            resultCollection.Add(checkAdd);
        }

        return resultCollection;
    }
}