using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Deflectors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.Deflector;

public class SecondDeflector : DeflectorBase
{
    private const int DeflectorSecondHealth = 100;
    private const int DeflectorSecondWeight = 200;

    public SecondDeflector()
    {
        Health = DeflectorSecondHealth;
        PartWeight = DeflectorSecondWeight;
    }
}