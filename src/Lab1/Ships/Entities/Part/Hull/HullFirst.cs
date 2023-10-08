using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Hull;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.Hull;

public class HullFirst : BaseHull
{
    public HullFirst()
    {
        HealthOfHull = HullFirstHealth;
        PartWeight = FirstHullWeight;
    }
}