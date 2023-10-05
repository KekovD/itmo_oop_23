namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ServiceabilityOfPart;

public abstract class PartServiceability : ICheckPartServiceability
{
    public bool Serviceability { get; protected set; } = true;

    public abstract void SetPartServiceability();
}