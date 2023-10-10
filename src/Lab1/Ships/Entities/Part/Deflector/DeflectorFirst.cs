using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Deflectors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.Deflector;

public class DeflectorFirst : BaseDeflector
{
    private const int DeflectorFirstHealth = 20;
    private const int DeflectorFirstWeight = 100;

    public DeflectorFirst()
    {
        Health = DeflectorFirstHealth;
        PartWeight += DeflectorFirstWeight;
    }
}