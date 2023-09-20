namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.EngineStatus;

public interface ITypeOfSpeed : IConstantEngineSpeed, IFunctionalDesignEngineSpeed, IPossibleJumpEngineDistance
{
    int TypeOfEngine(int grade);
}