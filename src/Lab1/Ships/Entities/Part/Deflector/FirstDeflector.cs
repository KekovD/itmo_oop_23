using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Deflectors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.Deflector;

public class FirstDeflector : DeflectorBase
{
    private const int DeflectorFirstHealth = 20;
    private const int DeflectorFirstWeight = 100;

    public FirstDeflector()
    {
        Health = DeflectorFirstHealth;
        PartWeight += DeflectorFirstWeight;
    }
}