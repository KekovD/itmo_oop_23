using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Hull;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.Hull;

public class HullSecond : BaseHull
{
    public HullSecond()
    {
        HealthOfHull = HullSecondHealth;
        PartWeight = SecondHullWeight;
    }
}