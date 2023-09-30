using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.DeflectorsInterfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.DeflectorsModels;

public abstract class GradeDeflectorIdentification : DeflectorTypeIdentification, IGradeDeflectorIdentification
{
    public HealthPointsDeflector DeflectorIdentification(int grade)
    {
        return grade switch
        {
            0 => HealthPointsDeflector.DeflectorBrokenHealth,
            1 => HealthPointsDeflector.DeflectorFirstHealth,
            2 => HealthPointsDeflector.DeflectorSecondHealth,
            3 => HealthPointsDeflector.DeflectorThirdHealth,
            _ => throw new System.ArgumentException("Invalid grade deflector value", nameof(grade)),
        };
    }
}