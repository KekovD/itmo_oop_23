using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.HullModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.HullEntities;

public class HullFirst : BaseHull
{
    public HullFirst()
    {
        HealthOfHull = HullFirstHealth;
        PartWeight = FirstHullWeight;
    }
}