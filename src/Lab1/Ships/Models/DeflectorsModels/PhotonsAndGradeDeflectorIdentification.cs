using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.DeflectorsInterfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.DeflectorsModels;

public abstract class PhotonsAndGradeDeflectorIdentification :
    GradeDeflectorIdentification, IHealthPointsPhotonsDeflector
{
    public bool DeflectAntimatterFlares { get; protected init; }
    public int PhotonsHealth { get; protected init; }

    public int InitPhotonsDeflectorHealthPoints(bool photons)
    {
        return photons switch
        {
            true => (int)HealthPointsPhotonsDeflector.PhotonsDeflectorsHealth,
            false => (int)HealthPointsPhotonsDeflector.PhotonsDeflectorBrokenOrBaseHealth,
        };
    }
}