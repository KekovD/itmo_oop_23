namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.HullModels;

public abstract class BaseHull : HullTypeIdentification
{
    protected BaseHull(int grade)
    {
        Gradation = grade;
        HealthOfHull = InitHealthPointsHull(grade);
    }
}