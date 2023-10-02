using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.DeflectorsInterfaces;
namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.DeflectorsModels;

public abstract class PhotonsAndGradeDeflectorIdentification : IHealthPointsPhotonsDeflector, IOperationalStatus
{
    public bool DeflectAntimatterFlares { get; protected init; }
    public int PhotonsHealth { get; protected init; }
    public bool Serviceability { get; protected set; }
}