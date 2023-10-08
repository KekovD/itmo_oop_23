using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.HullModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.HullEntities;

public class HullThird : BaseHull
{
    public HullThird()
    {
        HealthOfHull = HullThirdHealth;
        PartWeight = ThirdHullWeight;
    }
}