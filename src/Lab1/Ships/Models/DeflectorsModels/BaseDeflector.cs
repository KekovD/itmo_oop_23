using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.DeflectorsInterfaces;
namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.DeflectorsModels;

public class BaseDeflector : IHealthPointsPhotonsDeflector, IOperationalStatus, IClassOfDeflector, IPartWeight
{
    public bool DeflectAntimatterFlares { get; protected init; }
    public int PhotonsHealth { get; protected set; }
    public bool Serviceability { get; protected set; } = true;
    public int HealthOfDeflector { get; protected set;  }
    public int PartWeight { get; protected init; }
}