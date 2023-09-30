namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.DeflectorsModels;

public abstract class BaseAndGradeDeflector : PhotonsAndGradeDeflectorIdentification
{
    protected BaseAndGradeDeflector(int grade)
    {
        Gradation = grade;
        HealthOfDeflector = DeflectorIdentification(grade);
    }
}