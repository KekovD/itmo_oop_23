namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.DeflectorsModels;

public abstract class BaseDeflector : GradeDeflectorIdentification
{
    protected BaseDeflector(int grade)
    {
        Gradation = grade;
        HealthOfDeflector = DeflectorIdentification(grade);
    }
}