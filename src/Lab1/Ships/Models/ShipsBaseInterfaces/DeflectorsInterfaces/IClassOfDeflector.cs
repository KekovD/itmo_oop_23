using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.DeflectorsInterfaces;

public interface IClassOfDeflector : IGradationPart
{
    HealthPointsDeflector HealthOfDeflector { get; }
}