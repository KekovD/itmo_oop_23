using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.HullModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.HullEntities;

public class ThirdHull : BaseHull
{
    public ThirdHull()
    {
        HealthOfHull = (int)HealthPointHull.HullThirdHealth;
        PartWeight = (int)WeightOfHull.ThirdHullWeight;
    }
}