using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.DeflectorsInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.DeflectorsModels;

public abstract class PhotonsAndGradeDeflectorIdentification : GradeDeflectorIdentification, ICanDeflectAntimatterFlares
{
    public bool DeflectAntimatterFlares { get; protected set; }
    public void AntimatterDeflectorIdentification(bool deflect)
    {
        DeflectAntimatterFlares = deflect; ////TODO: refactor this
    }
}