using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ServiceabilityOfPart;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.PartInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.HullModels;

public class BaseHull : PartServiceability, IHullHealthPoint, IPartWeight
{
    protected const int HullFirstHealth = 15;
    protected const int HullSecondHealth = 85;
    protected const int HullThirdHealth = 205;
    protected const int FirstHullWeight = 1000;
    protected const int SecondHullWeight = 1500;
    protected const int ThirdHullWeight = 2000;
    public int HealthOfHull { get; protected set; }
    public int PartWeight { get; protected init; }
    public void SetHealthOfHull(int newValue)
    {
        HealthOfHull = newValue;
        SetPartServiceability();
    }

    public override void SetPartServiceability()
    {
        if (HealthOfHull <= 0)
        {
            Serviceability = false;
        }
    }
}