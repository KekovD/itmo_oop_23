using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Hull;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.Hull;

public class HullThird : BaseHull
{
    public HullThird()
    {
        HealthOfHull = HullThirdHealth;
        PartWeight = ThirdHullWeight;
    }
}