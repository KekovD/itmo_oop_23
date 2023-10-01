using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.HullInterfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.HullModels;

public abstract class HullTypeIdentification : IInitHealthPointsHull, IHullHealthPoint
{
    public int HealthOfHull { get; protected init; }
    public int Gradation { get; protected init; }
    public int InitHealthPointsHull(int grade) ////TODO: refactor exception
    {
        return grade switch
        {
            0 => throw new System.ArgumentException("Invalid grade hull value. Cannot be created broken", nameof(grade)),
            1 => (int)HealthPointHull.HullFirstHealth,
            2 => (int)HealthPointHull.HullSecondHealth,
            3 => (int)HealthPointHull.HullThirdHealth,
            _ => throw new System.ArgumentException("Invalid grade hull value", nameof(grade)),
        };
    }
}