using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.HullModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications.HullSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.HullEntities;

public class HullThird : BaseHull
{
    public HullThird()
    {
        HealthOfHull = (int)HealthPointHull.HullThirdHealth;
        PartWeight = (int)WeightOfHull.ThirdHullWeight;
    }
}