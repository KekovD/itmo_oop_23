using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.HullModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.HullEntities;

public class SecondHull : BaseHull
{
    public SecondHull()
    {
        HealthOfHull = (int)HealthPointHull.HullSecondHealth;
        PartWeight = (int)WeightOfHull.SecondHullWeight;
    }
}