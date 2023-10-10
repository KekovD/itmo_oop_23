using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Hull;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.Hull;

public class HullFirst : BaseHull
{
    private const int HullFirstHealth = 15;
    private const int FirstHullWeight = 1000;

    public HullFirst()
    {
        Health = HullFirstHealth;
        PartWeight = FirstHullWeight;
    }
}