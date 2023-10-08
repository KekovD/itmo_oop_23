namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ServiceabilityOfPart;

public interface IPartServiceability
{
    bool Serviceability { get; }
    void SetPartServiceability();
}