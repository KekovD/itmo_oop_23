using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.BaseInterfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ServiceabilityOfPart;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Hull;

public class BaseHull : PartServiceability, IPartWeight
{
    protected const int HullFirstHealth = 15;
    protected const int HullSecondHealth = 85;
    protected const int HullThirdHealth = 205;
    protected const int FirstHullWeight = 1000;
    protected const int SecondHullWeight = 1500;
    protected const int ThirdHullWeight = 2000;
    public int PartWeight { get; protected init; }
}