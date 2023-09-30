using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.DeflectorsInterfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.DeflectorsModels;

public abstract class DeflectorTypeIdentification : IClassOfDeflector
{
    public int Gradation { get; protected init; }
    public HealthPointsDeflector HealthOfDeflector { get; protected init;  }
}