using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces.RouteBaseInterface;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.EnvironmentsOfSpaceModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;
namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Services;

public abstract class OptimumShip : SingleCostOfRoute, IOptimumShip
{
    public int GetOptimumShip(IList<BaseShip> manyShips, ICollection<BaseSpace> manySegments)
    {
        var resultList = new List<int>();

        foreach (BaseShip ship in manyShips)
        {
            int totalCost = 0;

            foreach (BaseSpace segment in manySegments)
            {
                int segmentCost = GetSingleCostOfRoute(ship, segment, segment.RouteLength);
                totalCost += segmentCost;
            }

            resultList.Add(totalCost);
        }

        int minimumPrice = resultList.Min();
        int minimumPriseIndex = resultList.IndexOf(minimumPrice);
        return minimumPriseIndex;
    }
}