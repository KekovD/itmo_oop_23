namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces;

public interface IFuelExchange
{
    int SaveImpulseFuelPrice { get; }
    int SaveJumpFuelPrice { get; }
    int ImpulseFuelPrice();
    int JumpFuelPrice();
}