using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Hull;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.Hull;

public class FirstHull : HullBase
{
    private const int HullFirstHealth = 15;
    private const int FirstHullWeight = 1000;

    public FirstHull()
    {
        Health = HullFirstHealth;
        PartWeight = FirstHullWeight;
    }
}