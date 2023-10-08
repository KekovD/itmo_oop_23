using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ServiceabilityOfPart;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.PartInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.HullModels;

public class BaseHull : PartServiceability, IHullHealthPoint, IPartWeight
{
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