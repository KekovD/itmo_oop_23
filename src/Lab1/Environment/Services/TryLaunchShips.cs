using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.EnvironmentsOfSpaceModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Services;

public class TryLaunchShips : TrySingleTraverseRouteDistance
{
    public Collection<Collection<bool>> LaunchShips(ICollection<BaseShip> manyShips, ICollection<BaseSpace> manySegments)
    {
        var resultCollection = new Collection<Collection<bool>>();

        foreach (BaseSpace segment in manySegments)
        {
            var segmentResults = new Collection<bool>();
            foreach (BaseShip ship in manyShips)
            {
                bool tryResult = TryTraverseRouteDistance(ship, segment, segment.RouteLength);
                if (tryResult)
                {
                    tryResult = TryTraverseRouteDamage(ship, segment, segment.RouteLength);
                }

                segmentResults.Add(tryResult);
            }

            resultCollection.Add(segmentResults);
        }

        return resultCollection;
    }
}