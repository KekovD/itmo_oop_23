using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.HullModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.HullEntities;

public class HullSecond : BaseHull
{
    public HullSecond()
    {
        HealthOfHull = (int)HealthPointHull.HullSecondHealth;
        PartWeight = (int)WeightOfHull.SecondHullWeight;
    }
}