using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Hull;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.Hull;

public class ThirdHull : HullBase
{
    private const int HullSecondHealth = 85;
    private const int SecondHullWeight = 1500;

    public ThirdHull()
    {
        Health = HullSecondHealth;
        PartWeight = SecondHullWeight;
    }
}