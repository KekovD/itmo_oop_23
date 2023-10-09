using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ServiceabilityAndWeightPart;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Deflectors;

public class BaseDeflector : PartServiceabilityAndWeight
{
    protected const int DeflectorFirstHealth = 20;
    protected const int DeflectorSecondHealth = 100;
    protected const int DeflectorThirdHealth = 400;
    protected const int DeflectorFirstWeight = 100;
    protected const int DeflectorSecondWeight = 200;
    protected const int DeflectorThirdWeight = 300;
}