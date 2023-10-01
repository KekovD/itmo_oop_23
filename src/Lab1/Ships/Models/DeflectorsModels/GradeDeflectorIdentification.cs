using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.DeflectorsInterfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.DeflectorsModels;

public abstract class GradeDeflectorIdentification : DeflectorTypeIdentification, IGradeDeflectorIdentification
{
    public int DeflectorIdentification(int grade)
    {
        return grade switch
        {
            0 => (int)HealthPointsDeflector.DeflectorBrokenHealth,
            1 => (int)HealthPointsDeflector.DeflectorFirstHealth,
            2 => (int)HealthPointsDeflector.DeflectorSecondHealth,
            3 => (int)HealthPointsDeflector.DeflectorThirdHealth,
            _ => throw new System.ArgumentException("Invalid grade deflector value", nameof(grade)),
        };
    }
}