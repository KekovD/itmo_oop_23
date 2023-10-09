using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Deflectors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.Deflector;

public class DeflectorSecond : BaseDeflector
{
    public DeflectorSecond()
    {
        Health = DeflectorSecondHealth;
        PartWeight += DeflectorSecondWeight;
    }
}