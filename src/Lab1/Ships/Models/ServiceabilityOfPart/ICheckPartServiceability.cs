namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ServiceabilityOfPart;

public interface ICheckPartServiceability : IOperationalStatus
{
    void SetPartServiceability();
}