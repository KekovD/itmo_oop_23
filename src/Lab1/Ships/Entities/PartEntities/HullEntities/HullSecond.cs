using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.HullModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.HullEntities;

public class HullSecond : BaseHull
{
    public HullSecond()
    {
        HealthOfHull = HullSecondHealth;
        PartWeight = SecondHullWeight;
    }
}