using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.HullModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.HullEntities;

public class FirstHull : BaseHull
{
    public FirstHull()
    {
        HealthOfHull = (int)HealthPointHull.HullFirstHealth;
        PartWeight = (int)WeightOfHull.FirstHullWeight;
    }
}