namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.DeflectorsModels;

public abstract class BaseAndGradeDeflector : PhotonsAndGradeDeflectorIdentification
{
    protected BaseAndGradeDeflector(bool photons)
    {
        ////HealthOfDeflector = DeflectorIdentification(grade);
        DeflectAntimatterFlares = photons;
        ////PhotonsHealth = InitPhotonsDeflectorHealthPoints(photons);
        Serviceability = true;
    }
}