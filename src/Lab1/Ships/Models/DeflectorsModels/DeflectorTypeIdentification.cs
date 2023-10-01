using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.DeflectorsInterfaces;
namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.DeflectorsModels;

public abstract class DeflectorTypeIdentification : IClassOfDeflector
{
    public int Gradation { get; protected init; }
    public int HealthOfDeflector { get; protected init;  }
}