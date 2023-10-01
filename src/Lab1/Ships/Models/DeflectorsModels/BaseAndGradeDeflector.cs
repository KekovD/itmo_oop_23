namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.DeflectorsModels;

public abstract class BaseAndGradeDeflector : PhotonsAndGradeDeflectorIdentification
{
    protected BaseAndGradeDeflector(int grade, bool photons)
    {
        Gradation = grade;
        HealthOfDeflector = DeflectorIdentification(grade);
        DeflectAntimatterFlares = photons;
        PhotonsHealth = InitPhotonsDeflectorHealthPoints(photons);
    }
}