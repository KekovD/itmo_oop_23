using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Hull;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.Hull;

public class HullThird : BaseHull
{
    private const int HullThirdHealth = 205;
    private const int ThirdHullWeight = 2000;
    public HullThird()
    {
        Health = HullThirdHealth;
        PartWeight = ThirdHullWeight;
    }
}